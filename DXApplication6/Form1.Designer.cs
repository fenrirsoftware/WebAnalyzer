namespace DXApplication6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinRibbonGalleryBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            employeesBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            customersBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
          
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            dockPanel_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            groupBox1 = new System.Windows.Forms.GroupBox();
            checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            groupBox2 = new System.Windows.Forms.GroupBox();
            comboBox2 = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            textBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)checkedListBoxControl1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // ribbonControl
            // 
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, skinRibbonGalleryBarItem, employeesBarButtonItem, customersBarButtonItem, barButtonItem2, barButtonItem3 });
            ribbonControl.Location = new System.Drawing.Point(0, 0);
            ribbonControl.MaxItemId = 53;
            ribbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage });
            ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl.Size = new System.Drawing.Size(820, 158);
            ribbonControl.StatusBar = ribbonStatusBar;
            ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // skinRibbonGalleryBarItem
            // 
            skinRibbonGalleryBarItem.Id = 14;
            skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            // 
            // employeesBarButtonItem
            // 
            employeesBarButtonItem.Id = 48;
            employeesBarButtonItem.Name = "employeesBarButtonItem";
            // ss
            // customersBarButtonItem
            // 
            customersBarButtonItem.Id = 49;
            customersBarButtonItem.Name = "customersBarButtonItem";
            // 
            // barButtonItem1
            // 
            
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "DA/PA Test Modu";
            barButtonItem2.Id = 51;
            barButtonItem2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem2.ImageOptions.SvgImage");
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            // 
            // ribbonPage
            // 
            ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup });
            ribbonPage.Name = "ribbonPage";
            ribbonPage.Text = "View";
            // 
            // ribbonPageGroup
            // 
            ribbonPageGroup.AllowTextClipping = false;
            ribbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            ribbonPageGroup.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup.Name = "ribbonPageGroup";
            ribbonPageGroup.Text = "Test Modülü";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.Location = new System.Drawing.Point(0, 575);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbonControl;
            ribbonStatusBar.Size = new System.Drawing.Size(820, 24);
            // 
            // dockPanel_Container
            // 
            dockPanel_Container.Location = new System.Drawing.Point(3, 26);
            dockPanel_Container.Name = "dockPanel_Container";
            dockPanel_Container.Size = new System.Drawing.Size(193, 388);
            dockPanel_Container.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkedListBoxControl1);
            groupBox1.Location = new System.Drawing.Point(12, 164);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(236, 405);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Site Paneli";
            // 
            // checkedListBoxControl1
            // 
            checkedListBoxControl1.Location = new System.Drawing.Point(6, 20);
            checkedListBoxControl1.Name = "checkedListBoxControl1";
            checkedListBoxControl1.Size = new System.Drawing.Size(224, 379);
            checkedListBoxControl1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(simpleButton1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new System.Drawing.Point(254, 164);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(566, 148);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ayar Paneli";
            // 
            // comboBox2
            // 
            comboBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1", "7", "28", "60", "90", "120", "240", "365" });
            comboBox2.Location = new System.Drawing.Point(151, 51);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(62, 27);
            comboBox2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            label3.Location = new System.Drawing.Point(7, 51);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(420, 25);
            label3.TabIndex = 5;
            label3.Text = "Google verileri          günlük sonuçlar olsun";
            // 
            // simpleButton1
            // 
            simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            simpleButton1.Appearance.Options.UseFont = true;
            simpleButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            simpleButton1.Location = new System.Drawing.Point(151, 84);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(218, 58);
            simpleButton1.TabIndex = 4;
            simpleButton1.Text = "Veri iletimini başlat";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            textBox1.Location = new System.Drawing.Point(69, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(191, 26);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            label2.Location = new System.Drawing.Point(0, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(540, 25);
            label2.TabIndex = 2;
            label2.Text = "Veriler                            E-Posta adresine gönderilsin.";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(richTextBox1);
            groupBox3.Location = new System.Drawing.Point(248, 318);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(566, 245);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Log";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new System.Drawing.Point(6, 14);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(554, 208);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "barButtonItem3";
            barButtonItem3.Id = 52;
            barButtonItem3.Name = "barButtonItem3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(820, 599);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(ribbonStatusBar);
            Controls.Add(ribbonControl);
            Name = "Form1";
            Ribbon = ribbonControl;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            StatusBar = ribbonStatusBar;
            Text = "WebMaster";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)checkedListBoxControl1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem;
        private DevExpress.XtraBars.BarButtonItem employeesBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem customersBarButtonItem;
       
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel_Container;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}