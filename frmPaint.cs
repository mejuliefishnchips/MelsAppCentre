using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MelsAppCentre
{
    public partial class frmPaint : Form
    {
        public frmPaint()
        {
            InitializeComponent();
            loadCanvas();

            //Select Pen by default
            selectedSetting = btnPen;
            selectedSetting.BackColor = Color.Pink;

        }

        Bitmap paintImage;
        Bitmap drawImage;
        Bitmap workingImage;

        Graphics workingGraphics;
        Graphics drawGraphics;
        Graphics p;
        Graphics h;
        Graphics global;

        Bitmap imageBackground;
        //Image imageBackground;

        Brush myBrush = new SolidBrush(Color.Pink);
        Point lastPoint;
        bool isMouseDown = false;

        private void loadCanvas()
        {
            int width = canvas.Width;
            int height = canvas.Height;

            //loads a white canvas at start of Paint program
            paintImage = new Bitmap(width, height);
            p = Graphics.FromImage(paintImage);

            p.FillRectangle(Brushes.White, 0, 0, width, height);

            canvas.BackgroundImage = paintImage;

            canvas.MouseDown += new MouseEventHandler(Canvas_MouseDown);
            canvas.MouseMove += new MouseEventHandler(Canvas_MouseMove);
            canvas.MouseUp += new MouseEventHandler(Canvas_MouseUp);

        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            if (selectedSetting.Text != "Pen")
            {
                //Draw again to get the shape without border
                DrawShapeInWorkingImage(e.Location);

                /*
                if (canvas.Image == drawImage)
                    global = drawGraphics;
                else if (canvas.Image == imageBackground)
                {
                    paintImage = new Bitmap(imageBackground);
                    p = Graphics.FromImage(imageBackground);
                }
                else if (canvas.Image == paintImage)
                {
                    paintImage = new Bitmap(workingImage);
                    p = Graphics.FromImage(paintImage);
                }
                else
                    global = workingGraphics;
                */

                paintImage = new Bitmap(workingImage);

                p = Graphics.FromImage(paintImage);

                canvas.Image = paintImage;
                // canvas.Refresh();

            }

        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (selectedSetting.Text == "Pen")
                {
                    DrawLineOnCanvas(e.Location);
                }
                else
                {
                    DrawShapeInWorkingImage(e.Location);
                }

            }
        }

        private void DrawLineOnCanvas(Point currentPoint)
        {

            if (canvas.Image == drawImage)
                global = drawGraphics;
            else if (canvas.Image == imageBackground)
                global = h;
            else if (canvas.Image == paintImage)
                global = p;
            else
                global = workingGraphics;


            Pen myPen = new Pen(colorPicker.Color, trackBarSize.Value);
            global.DrawLine(myPen, lastPoint, currentPoint);

            lastPoint = currentPoint;

            canvas.Refresh();
        }

        private void DrawShapeInWorkingImage(Point currentPoint)
        {
            Pen myPen = new Pen(colorPicker.Color, trackBarSize.Value);


            workingImage = new Bitmap(paintImage);
            workingGraphics = Graphics.FromImage(workingImage);

            int startPointX = lastPoint.X < currentPoint.X ? lastPoint.X : currentPoint.X;
            int startPointY = lastPoint.Y < currentPoint.Y ? lastPoint.Y : currentPoint.Y;

            int shapeWidth = (lastPoint.X > currentPoint.X ? lastPoint.X : currentPoint.X) - startPointX;
            int shapeHeight = (lastPoint.Y > currentPoint.Y ? lastPoint.Y : currentPoint.Y) - startPointY;
            /*
            if (canvas.Image == drawImage)
            {
                global = drawGraphics;
                workingImage = drawImage;
                canvas.Refresh();
            }
            else if (canvas.Image == imageBackground)
            {
                global = h;
                workingImage = imageBackground;
                canvas.Refresh();
            }
            else if (canvas.Image == paintImage)
            {
                global = p;
                workingImage = paintImage;
                canvas.Refresh();
            }
            else
            {
                global = workingGraphics;
                canvas.Refresh();

            }
            */

            switch (selectedSetting.Text)
            {
                case "Rectangle":
                    //Check if fill color box is ticked
                    if (!chkboxFillColor.Checked)
                    {
                        //Draw Rectangle
                        workingGraphics.DrawRectangle(myPen, startPointX, startPointY, shapeWidth, shapeHeight);
                    }
                    else
                    {
                        //Fill Rectangle
                        workingGraphics.FillRectangle(myPen.Brush, startPointX, startPointY, shapeWidth, shapeHeight);
                    }
                    break;
                case "Circle":
                    //Check if fill color box is ticked
                    if (!chkboxFillColor.Checked)
                    {
                        //Draw Circle
                        workingGraphics.DrawEllipse(myPen, startPointX, startPointY, shapeWidth, shapeHeight);
                    }
                    else
                    {
                        //Fill Circle
                        workingGraphics.FillEllipse(myPen.Brush, startPointX, startPointY, shapeWidth, shapeHeight);
                    }
                    break;
                case "Triangle":
                    Point point1 = new Point() { X = startPointX, Y = startPointY + shapeHeight };
                    Point point2 = new Point() { X = startPointX + (shapeWidth / 2), Y = startPointY };
                    Point point3 = new Point() { X = startPointX + shapeWidth, Y = startPointY + shapeHeight };

                    //Check if fill color box is ticked
                    if (!chkboxFillColor.Checked)
                    {
                        //Draw Triangle
                        workingGraphics.DrawPolygon(myPen, new Point[] { point1, point2, point3 });
                    }
                    else
                    {
                        //Fill Triangle
                        workingGraphics.FillPolygon(myPen.Brush, new Point[] { point1, point2, point3 });
                    }
                    break;
                case "Line":

                    workingGraphics.DrawLine(myPen, lastPoint, currentPoint);
                    break;
            }


            if (isMouseDown && selectedSetting.Text != "Line")
            {
                //Draw Outline while drawing shapes
                Pen outlinePen = new Pen(Color.Black);
                outlinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                workingGraphics.DrawRectangle(outlinePen, startPointX, startPointY, shapeWidth, shapeHeight);

            }


            canvas.Image = workingImage;
            // canvas.Refresh();
        }

        private void frmPaint_Load(object sender, EventArgs e)
        {
            //Enable drag & drop for this form
            this.AllowDrop = true;

            //Add event handlers for drag & drop functionality
            this.DragEnter += new DragEventHandler(FrmPaint_DragEnter);
            this.DragDrop += new DragEventHandler(FrmPaint_DragDrop);
        }

        //event when mouse is released over the form
        private void FrmPaint_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string File in FileList)
                this.lblFile.Text = File;

            string imageName = lblFile.Text;

            loadImage(imageName);

        }

        private void loadImage(string imageName)
        {
            //reading image location saved through drag and drop and opening it as the canvas
            //imageBackground = Image.FromFile(imageName);

            imageBackground = new Bitmap(imageName);
            h = Graphics.FromImage(imageBackground);

            canvas.Image = imageBackground;

        }

        // Event when mouse is dragged over the form
        private void FrmPaint_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        ColorDialog colorPicker = new ColorDialog();

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            colorPicker.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Button selectedSetting;

        private void btnPen_Click(object sender, EventArgs e)
        {
            selectedSetting.BackColor = SystemColors.Control;

            Button clickedButton = sender as Button;
            clickedButton.BackColor = Color.Pink;

            selectedSetting = clickedButton;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            selectedSetting.BackColor = SystemColors.Control;

            Button clickedButton = sender as Button;
            clickedButton.BackColor = Color.Pink;

            selectedSetting = clickedButton;
        }


        //Draw For Me Button - draws a house landscape
        private void btnDrawForMe_Click(object sender, EventArgs e)
        {
            //Drawing of House at click event
            // Canvas Width = 493
            // Canvas Height = 370
            drawImage = new Bitmap(paintImage);
            drawGraphics = Graphics.FromImage(drawImage);
            //sky
            drawGraphics.FillRectangle(Pens.SkyBlue.Brush, 0, 0, canvas.Width, 250);
            //grass
            drawGraphics.FillRectangle(Pens.LawnGreen.Brush, 0, 250, canvas.Width, 120);
            //house
            drawGraphics.FillRectangle(Pens.BlanchedAlmond.Brush, 46, 190, 400, 160);
            //ceiling
            drawGraphics.FillPolygon(Pens.Orchid.Brush, new Point[] { (new Point(31, 190)), (new Point(246, 90)), (new Point(460, 190)) });
            //sun
            drawGraphics.FillEllipse(Pens.Yellow.Brush, 400, 20, 70, 70);
            //door
            drawGraphics.FillRectangle(Pens.MediumPurple.Brush, 210, 240, 80, 110);
            //windows
            drawGraphics.FillRectangle(Pens.HotPink.Brush, 80, 220, 100, 50);
            drawGraphics.FillRectangle(Pens.HotPink.Brush, 313, 220, 100, 50);

            canvas.Image = drawImage;


        }

        private void btnClearCanvas_Click(object sender, EventArgs e)
        {
            if (canvas.Image == drawImage)
                drawGraphics.Clear(Color.White);
            else if (canvas.Image == imageBackground)  //ISSUE: when image is cleared the cnavas is still at the image size
                h.Clear(Color.White);
            else if (canvas.Image == paintImage)
                p.Clear(Color.White);
            else
                workingGraphics.Clear(Color.White);


            lblFile.Text = "Drag and Drop Image to set as Background";

            canvas.Refresh();


        }
    }
}
