namespace MinWageApp {
    partial class PickValueForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickValueForm));
            this.dgvValues = new System.Windows.Forms.DataGridView();
            this.tsButtons = new System.Windows.Forms.ToolStrip();
            this.btnOk = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.simInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scenarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.populationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workforceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wageSegmentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topIncomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minWageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genIncAboveInfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minIncAboveInfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dispFactorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.truncDispDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.saveWageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estInflationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iterationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reshapeCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enforceMinDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.maxGrowthPctDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).BeginInit();
            this.tsButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simInputBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvValues
            // 
            this.dgvValues.AutoGenerateColumns = false;
            this.dgvValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.countryDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.scenarioDataGridViewTextBoxColumn,
            this.gdpDataGridViewTextBoxColumn,
            this.importsDataGridViewTextBoxColumn,
            this.populationDataGridViewTextBoxColumn,
            this.workforceDataGridViewTextBoxColumn,
            this.wageSegmentsDataGridViewTextBoxColumn,
            this.topIncomeDataGridViewTextBoxColumn,
            this.minWageDataGridViewTextBoxColumn,
            this.genIncAboveInfDataGridViewTextBoxColumn,
            this.minIncAboveInfDataGridViewTextBoxColumn,
            this.dispFactorDataGridViewTextBoxColumn,
            this.truncDispDataGridViewCheckBoxColumn,
            this.saveWageDataGridViewTextBoxColumn,
            this.estInflationDataGridViewTextBoxColumn,
            this.iterationsDataGridViewTextBoxColumn,
            this.reshapeCountDataGridViewTextBoxColumn,
            this.enforceMinDataGridViewCheckBoxColumn,
            this.maxGrowthPctDataGridViewTextBoxColumn});
            this.dgvValues.DataSource = this.simInputBindingSource;
            this.dgvValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValues.Location = new System.Drawing.Point(0, 0);
            this.dgvValues.Name = "dgvValues";
            this.dgvValues.RowTemplate.Height = 24;
            this.dgvValues.Size = new System.Drawing.Size(1000, 447);
            this.dgvValues.TabIndex = 0;
            // 
            // tsButtons
            // 
            this.tsButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsButtons.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOk,
            this.btnCancel});
            this.tsButtons.Location = new System.Drawing.Point(0, 447);
            this.tsButtons.Name = "tsButtons";
            this.tsButtons.Size = new System.Drawing.Size(1000, 31);
            this.tsButtons.TabIndex = 1;
            this.tsButtons.Text = "toolStrip1";
            // 
            // btnOk
            // 
            this.btnOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(28, 28);
            this.btnOk.Text = "toolStripButton1";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 28);
            this.btnCancel.Text = "toolStripButton2";
            // 
            // simInputBindingSource
            // 
            this.simInputBindingSource.DataSource = typeof(MinWageApp.SimInput);
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // scenarioDataGridViewTextBoxColumn
            // 
            this.scenarioDataGridViewTextBoxColumn.DataPropertyName = "Scenario";
            this.scenarioDataGridViewTextBoxColumn.HeaderText = "Scenario";
            this.scenarioDataGridViewTextBoxColumn.Name = "scenarioDataGridViewTextBoxColumn";
            // 
            // gdpDataGridViewTextBoxColumn
            // 
            this.gdpDataGridViewTextBoxColumn.DataPropertyName = "Gdp";
            this.gdpDataGridViewTextBoxColumn.HeaderText = "Gdp";
            this.gdpDataGridViewTextBoxColumn.Name = "gdpDataGridViewTextBoxColumn";
            // 
            // importsDataGridViewTextBoxColumn
            // 
            this.importsDataGridViewTextBoxColumn.DataPropertyName = "Imports";
            this.importsDataGridViewTextBoxColumn.HeaderText = "Imports";
            this.importsDataGridViewTextBoxColumn.Name = "importsDataGridViewTextBoxColumn";
            // 
            // populationDataGridViewTextBoxColumn
            // 
            this.populationDataGridViewTextBoxColumn.DataPropertyName = "Population";
            this.populationDataGridViewTextBoxColumn.HeaderText = "Population";
            this.populationDataGridViewTextBoxColumn.Name = "populationDataGridViewTextBoxColumn";
            // 
            // workforceDataGridViewTextBoxColumn
            // 
            this.workforceDataGridViewTextBoxColumn.DataPropertyName = "Workforce";
            this.workforceDataGridViewTextBoxColumn.HeaderText = "Workforce";
            this.workforceDataGridViewTextBoxColumn.Name = "workforceDataGridViewTextBoxColumn";
            // 
            // wageSegmentsDataGridViewTextBoxColumn
            // 
            this.wageSegmentsDataGridViewTextBoxColumn.DataPropertyName = "WageSegments";
            this.wageSegmentsDataGridViewTextBoxColumn.HeaderText = "WageSegments";
            this.wageSegmentsDataGridViewTextBoxColumn.Name = "wageSegmentsDataGridViewTextBoxColumn";
            // 
            // topIncomeDataGridViewTextBoxColumn
            // 
            this.topIncomeDataGridViewTextBoxColumn.DataPropertyName = "TopIncome";
            this.topIncomeDataGridViewTextBoxColumn.HeaderText = "TopIncome";
            this.topIncomeDataGridViewTextBoxColumn.Name = "topIncomeDataGridViewTextBoxColumn";
            // 
            // minWageDataGridViewTextBoxColumn
            // 
            this.minWageDataGridViewTextBoxColumn.DataPropertyName = "MinWage";
            this.minWageDataGridViewTextBoxColumn.HeaderText = "MinWage";
            this.minWageDataGridViewTextBoxColumn.Name = "minWageDataGridViewTextBoxColumn";
            // 
            // genIncAboveInfDataGridViewTextBoxColumn
            // 
            this.genIncAboveInfDataGridViewTextBoxColumn.DataPropertyName = "GenIncAboveInf";
            this.genIncAboveInfDataGridViewTextBoxColumn.HeaderText = "GenIncAboveInf";
            this.genIncAboveInfDataGridViewTextBoxColumn.Name = "genIncAboveInfDataGridViewTextBoxColumn";
            // 
            // minIncAboveInfDataGridViewTextBoxColumn
            // 
            this.minIncAboveInfDataGridViewTextBoxColumn.DataPropertyName = "MinIncAboveInf";
            this.minIncAboveInfDataGridViewTextBoxColumn.HeaderText = "MinIncAboveInf";
            this.minIncAboveInfDataGridViewTextBoxColumn.Name = "minIncAboveInfDataGridViewTextBoxColumn";
            // 
            // dispFactorDataGridViewTextBoxColumn
            // 
            this.dispFactorDataGridViewTextBoxColumn.DataPropertyName = "DispFactor";
            this.dispFactorDataGridViewTextBoxColumn.HeaderText = "DispFactor";
            this.dispFactorDataGridViewTextBoxColumn.Name = "dispFactorDataGridViewTextBoxColumn";
            // 
            // truncDispDataGridViewCheckBoxColumn
            // 
            this.truncDispDataGridViewCheckBoxColumn.DataPropertyName = "TruncDisp";
            this.truncDispDataGridViewCheckBoxColumn.HeaderText = "TruncDisp";
            this.truncDispDataGridViewCheckBoxColumn.Name = "truncDispDataGridViewCheckBoxColumn";
            // 
            // saveWageDataGridViewTextBoxColumn
            // 
            this.saveWageDataGridViewTextBoxColumn.DataPropertyName = "SaveWage";
            this.saveWageDataGridViewTextBoxColumn.HeaderText = "SaveWage";
            this.saveWageDataGridViewTextBoxColumn.Name = "saveWageDataGridViewTextBoxColumn";
            // 
            // estInflationDataGridViewTextBoxColumn
            // 
            this.estInflationDataGridViewTextBoxColumn.DataPropertyName = "EstInflation";
            this.estInflationDataGridViewTextBoxColumn.HeaderText = "EstInflation";
            this.estInflationDataGridViewTextBoxColumn.Name = "estInflationDataGridViewTextBoxColumn";
            // 
            // iterationsDataGridViewTextBoxColumn
            // 
            this.iterationsDataGridViewTextBoxColumn.DataPropertyName = "Iterations";
            this.iterationsDataGridViewTextBoxColumn.HeaderText = "Iterations";
            this.iterationsDataGridViewTextBoxColumn.Name = "iterationsDataGridViewTextBoxColumn";
            // 
            // reshapeCountDataGridViewTextBoxColumn
            // 
            this.reshapeCountDataGridViewTextBoxColumn.DataPropertyName = "ReshapeCount";
            this.reshapeCountDataGridViewTextBoxColumn.HeaderText = "ReshapeCount";
            this.reshapeCountDataGridViewTextBoxColumn.Name = "reshapeCountDataGridViewTextBoxColumn";
            // 
            // enforceMinDataGridViewCheckBoxColumn
            // 
            this.enforceMinDataGridViewCheckBoxColumn.DataPropertyName = "EnforceMin";
            this.enforceMinDataGridViewCheckBoxColumn.HeaderText = "EnforceMin";
            this.enforceMinDataGridViewCheckBoxColumn.Name = "enforceMinDataGridViewCheckBoxColumn";
            // 
            // maxGrowthPctDataGridViewTextBoxColumn
            // 
            this.maxGrowthPctDataGridViewTextBoxColumn.DataPropertyName = "MaxGrowthPct";
            this.maxGrowthPctDataGridViewTextBoxColumn.HeaderText = "MaxGrowthPct";
            this.maxGrowthPctDataGridViewTextBoxColumn.Name = "maxGrowthPctDataGridViewTextBoxColumn";
            // 
            // PickValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 478);
            this.Controls.Add(this.dgvValues);
            this.Controls.Add(this.tsButtons);
            this.Name = "PickValueForm";
            this.Text = "Pick Simulation";
            this.Load += new System.EventHandler(this.PickValueForm_Load);
            this.Shown += new System.EventHandler(this.PickValueForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).EndInit();
            this.tsButtons.ResumeLayout(false);
            this.tsButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simInputBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvValues;
        private System.Windows.Forms.ToolStrip tsButtons;
        private System.Windows.Forms.ToolStripButton btnOk;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scenarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gdpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn populationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workforceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wageSegmentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn topIncomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minWageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genIncAboveInfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minIncAboveInfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dispFactorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn truncDispDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saveWageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estInflationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iterationsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reshapeCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enforceMinDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxGrowthPctDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource simInputBindingSource;
    }
}