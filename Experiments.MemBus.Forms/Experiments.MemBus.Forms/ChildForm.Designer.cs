namespace Experiments.MemBus.Forms
{
    partial class ChildForm
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
            this.BusDataList = new System.Windows.Forms.ListView();
            this.TimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LatitudeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LongitudeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // BusDataList
            // 
            this.BusDataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TimeColumn,
            this.TitleColumn,
            this.LatitudeColumn,
            this.LongitudeColumn});
            this.BusDataList.Location = new System.Drawing.Point(12, 12);
            this.BusDataList.Name = "BusDataList";
            this.BusDataList.Size = new System.Drawing.Size(335, 97);
            this.BusDataList.TabIndex = 0;
            this.BusDataList.UseCompatibleStateImageBehavior = false;
            this.BusDataList.View = System.Windows.Forms.View.Details;
            // 
            // TimeColumn
            // 
            this.TimeColumn.Text = "Time";
            this.TimeColumn.Width = 128;
            // 
            // TitleColumn
            // 
            this.TitleColumn.Text = "Title";
            // 
            // LatitudeColumn
            // 
            this.LatitudeColumn.Text = "Latitude";
            // 
            // LongitudeColumn
            // 
            this.LongitudeColumn.Text = "Longitude";
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 125);
            this.Controls.Add(this.BusDataList);
            this.Name = "ChildForm";
            this.Text = "ChildForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView BusDataList;
        private System.Windows.Forms.ColumnHeader TimeColumn;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader LatitudeColumn;
        private System.Windows.Forms.ColumnHeader LongitudeColumn;
    }
}