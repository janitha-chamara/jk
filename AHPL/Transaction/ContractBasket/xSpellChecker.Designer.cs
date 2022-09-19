namespace MMS.Transaction.ContractBasket
{
    partial class xSpellChecker
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary spellCheckerISpellDictionary1 = new DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xSpellChecker));
            DevExpress.XtraSpellChecker.OptionsSpelling optionsSpelling1 = new DevExpress.XtraSpellChecker.OptionsSpelling();
            this.btnCheckSpelling = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.spellChecker1 = new DevExpress.XtraSpellChecker.SpellChecker();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.SuspendLayout();
            // 
            // btnCheckSpelling
            // 
            this.btnCheckSpelling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckSpelling.Location = new System.Drawing.Point(690, 47);
            this.btnCheckSpelling.Name = "btnCheckSpelling";
            this.btnCheckSpelling.Size = new System.Drawing.Size(96, 23);
            this.btnCheckSpelling.TabIndex = 0;
            this.btnCheckSpelling.Text = "Check Spelling";
            this.btnCheckSpelling.Click += new System.EventHandler(this.btnCheckSpelling_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(690, 77);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // spellChecker1
            // 
            this.spellChecker1.Culture = new System.Globalization.CultureInfo("en-US");
            spellCheckerISpellDictionary1.AlphabetPath = "Dictionaries\\EnglishAlphabet.txt";
            spellCheckerISpellDictionary1.CacheKey = null;
            spellCheckerISpellDictionary1.Culture = new System.Globalization.CultureInfo("en-US");
            spellCheckerISpellDictionary1.DictionaryPath = "Dictionaries\\american.xlg";
            spellCheckerISpellDictionary1.Encoding = ((System.Text.Encoding)(resources.GetObject("spellCheckerISpellDictionary1.Encoding")));
            spellCheckerISpellDictionary1.GrammarPath = "Dictionaries\\english.aff";
            this.spellChecker1.Dictionaries.Add(spellCheckerISpellDictionary1);
            this.spellChecker1.LoadOnDemand = true;
            this.spellChecker1.ParentContainer = null;
            // 
            // richEditControl1
            // 
            this.richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.richEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richEditControl1.Location = new System.Drawing.Point(12, 12);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Options.AutoCorrect.UseSpellCheckerSuggestions = true;
            this.richEditControl1.Options.Behavior.TabMarker = "";
            this.richEditControl1.Options.DocumentCapabilities.CharacterFormatting = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.CharacterStyle = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.Numbering.Bulleted = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.Numbering.MultiLevel = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.Numbering.Simple = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.ParagraphFormatting = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.Paragraphs = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.ParagraphStyle = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.ParagraphTabs = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.TabSymbol = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.DocumentCapabilities.Undo = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            this.richEditControl1.Options.FormattingMarkVisibility.HiddenText = DevExpress.XtraRichEdit.RichEditFormattingMarkVisibility.Hidden;
            this.richEditControl1.Options.FormattingMarkVisibility.ParagraphMark = DevExpress.XtraRichEdit.RichEditFormattingMarkVisibility.Hidden;
            this.richEditControl1.Options.FormattingMarkVisibility.Space = DevExpress.XtraRichEdit.RichEditFormattingMarkVisibility.Hidden;
            this.richEditControl1.Options.FormattingMarkVisibility.TabCharacter = DevExpress.XtraRichEdit.RichEditFormattingMarkVisibility.Hidden;
            this.richEditControl1.Options.TableOptions.GridLines = DevExpress.XtraRichEdit.RichEditTableGridLinesVisibility.Hidden;
            this.spellChecker1.SetShowSpellCheckMenu(this.richEditControl1, false);
            this.richEditControl1.Size = new System.Drawing.Size(655, 218);
            this.richEditControl1.SpellChecker = this.spellChecker1;
            this.spellChecker1.SetSpellCheckerOptions(this.richEditControl1, optionsSpelling1);
            this.richEditControl1.TabIndex = 2;
            this.richEditControl1.Text = "richEditControl1";
            this.richEditControl1.Views.PrintLayoutView.PageHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xSpellChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 242);
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCheckSpelling);
            this.Name = "xSpellChecker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spell Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xSpellChecker_FormClosing);
            this.Load += new System.EventHandler(this.xSpellChecker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCheckSpelling;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraSpellChecker.SpellChecker spellChecker1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
    }
}