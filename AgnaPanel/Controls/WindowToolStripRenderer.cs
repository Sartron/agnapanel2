using System.Drawing;
using System.Windows.Forms;

namespace AgnaPanel.Controls
{
    class WindowColorTable : ProfessionalColorTable
    {
        public override Color ToolStripBorder
        {
            get { return Color.FromName("Window"); }
        }
        public override Color ToolStripGradientBegin
        {
            get { return Color.FromName("Window"); }
        }
        public override Color ToolStripGradientMiddle
        {
            get { return Color.FromName("Window"); }
        }
        public override Color ToolStripGradientEnd
        {
            get { return Color.FromName("Window"); }
        }
        public override Color OverflowButtonGradientBegin
        {
            get { return Color.FromName("Window"); }
        }
        public override Color OverflowButtonGradientMiddle
        {
            get { return Color.FromName("Window"); }
        }
        public override Color OverflowButtonGradientEnd
        {
            get { return Color.FromName("Window"); }
        }
    }

    class WindowToolStripRenderer : ToolStripProfessionalRenderer
    {
        public WindowToolStripRenderer() : base(new WindowColorTable()) { }
    }
}