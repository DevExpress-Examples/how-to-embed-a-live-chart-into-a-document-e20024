﻿namespace BizPad {
    using DevExpress.XtraBars.Ribbon;

    public partial class Editor : RibbonForm {
        public Editor() {
            InitializeComponent();
            this.richEdit.LoadDocument("Chart.docx");
        }
    }
}
