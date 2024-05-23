namespace PIU_Project_With_Forms
{
    partial class VehicleSelection
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
            this.CarSelect = new System.Windows.Forms.Button();
            this.TruckSelect = new System.Windows.Forms.Button();
            this.MotorcycleSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CarSelect
            // 
            this.CarSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarSelect.Location = new System.Drawing.Point(30, 13);
            this.CarSelect.Name = "CarSelect";
            this.CarSelect.Size = new System.Drawing.Size(77, 34);
            this.CarSelect.TabIndex = 0;
            this.CarSelect.Text = "Car";
            this.CarSelect.UseVisualStyleBackColor = true;
            this.CarSelect.Click += new System.EventHandler(this.CarSelect_Click);
            // 
            // TruckSelect
            // 
            this.TruckSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TruckSelect.Location = new System.Drawing.Point(113, 13);
            this.TruckSelect.Name = "TruckSelect";
            this.TruckSelect.Size = new System.Drawing.Size(77, 34);
            this.TruckSelect.TabIndex = 1;
            this.TruckSelect.Text = "Truck";
            this.TruckSelect.UseVisualStyleBackColor = true;
            this.TruckSelect.Click += new System.EventHandler(this.TruckSelect_Click);
            // 
            // MotorcycleSelect
            // 
            this.MotorcycleSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotorcycleSelect.Location = new System.Drawing.Point(196, 13);
            this.MotorcycleSelect.Name = "MotorcycleSelect";
            this.MotorcycleSelect.Size = new System.Drawing.Size(124, 34);
            this.MotorcycleSelect.TabIndex = 2;
            this.MotorcycleSelect.Text = "Motorcycle";
            this.MotorcycleSelect.UseVisualStyleBackColor = true;
            this.MotorcycleSelect.Click += new System.EventHandler(this.MotorcycleSelect_Click);
            // 
            // VehicleSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.MotorcycleSelect);
            this.Controls.Add(this.TruckSelect);
            this.Controls.Add(this.CarSelect);
            this.Name = "VehicleSelection";
            this.Size = new System.Drawing.Size(350, 406);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CarSelect;
        private System.Windows.Forms.Button TruckSelect;
        private System.Windows.Forms.Button MotorcycleSelect;
    }
}
