using System;
using System.Windows.Forms;


namespace WangPluginPkm
{
    public partial class PkmCondition : UserControl
    {
        public CheckRules rules = new();
        private ShinyType selectedShiny = ShinyType.None;
        private MethodType RNGMethod = MethodType.None;
        public enum ShinyType
        {
            None,
            Shiny,
            Star,
            Sqaure,
            ForceStar,
        }

        public PkmCondition()
        {
            InitializeComponent();
            BindingData();
        }
        private void BindingData()
        {
            this.HpMin.DataBindings.Add("Text", rules, "minHP");
            this.HpMax.DataBindings.Add("Text", rules, "maxHP");
            this.AtkMin.DataBindings.Add("Text", rules, "minAtk");
            this.AtkMax.DataBindings.Add("Text", rules, "maxAtk");
            this.DefMin.DataBindings.Add("Text", rules, "minDef");
            this.DefMax.DataBindings.Add("Text", rules, "maxDef");
            this.SpaMin.DataBindings.Add("Text", rules, "minSpA");
            this.SpaMax.DataBindings.Add("Text", rules, "maxSpA");
            this.SpdMin.DataBindings.Add("Text", rules, "minSpD");
            this.SpdMax.DataBindings.Add("Text", rules, "maxSpD");
            this.SpeMin.DataBindings.Add("Text", rules, "minSpe");
            this.SpeMax.DataBindings.Add("Text", rules, "maxSpe");
            this.MethodBox.DataSource = Enum.GetNames(typeof(MethodType));
            this.MethodBox.SelectedIndexChanged += (_, __) =>
            {
                RNGMethod = (MethodType)Enum.Parse(typeof(MethodType), this.MethodBox.SelectedItem.ToString(), false);
                rules.Method = RNGMethod;
            };
            this.MethodBox.SelectedIndex = 0;
            this.ShinyTypeBox1.DataSource = Enum.GetNames(typeof(ShinyType));
            this.ShinyTypeBox1.SelectedIndexChanged += (_, __) =>
            {
                selectedShiny = (ShinyType)Enum.Parse(typeof(ShinyType), this.ShinyTypeBox1.SelectedItem.ToString(), false);
               // rules.Shiny = selectedShiny;
            };
            this.ShinyTypeBox1.SelectedIndex = 0;

        }
        private void IVS_TextChanged(object sender, EventArgs e)
        {
            var txtbox = (TextBox)sender;

            if (!uint.TryParse(txtbox.Text, out var iv))
                iv = 0;
            if (iv < 0 || iv > 31)
            {
                iv = 0;
                txtbox.Text = "0";
            }
        }

    }
}
