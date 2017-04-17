using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EndTerm
{
    public partial class Shape : UserControl
    {
        private ShapeType shape = ShapeType.Circle;
        private GraphicsPath path = null;
        public enum ShapeType { Circle }
        private void make()
        {
            toolTip2 = new ToolTip();
            path = new GraphicsPath();
            switch (shape)
            {
                case ShapeType.Circle:
                    path.AddEllipse(this.ClientRectangle);
                    break;
            }
            this.Region = new Region(path);
        }
        public ShapeType Type
        {
            get { return shape; }
            set
            {
                shape = value;
                make();
            }
        }
        
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (path != null)
            {
                e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
                e.Graphics.DrawPath(new Pen(this.ForeColor, 4), path);
            }
        }
        protected override void OnResize(System.EventArgs e)
        {
            make();
            this.Invalidate();
        }

        public string ShapeName
        {
            get
            {
                return toolTip2.GetToolTip(this);
            }
            set
            {
                toolTip2.SetToolTip(this, value);
            }
        }
    }
}
