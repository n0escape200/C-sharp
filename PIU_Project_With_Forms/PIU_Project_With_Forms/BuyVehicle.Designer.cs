﻿namespace PIU_Project_With_Forms
{
    partial class BuyVehicle
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
            this.buyBox = new System.Windows.Forms.Button();
            this.indexBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buyBox
            // 
            this.buyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyBox.Location = new System.Drawing.Point(70, 46);
            this.buyBox.Name = "buyBox";
            this.buyBox.Size = new System.Drawing.Size(101, 33);
            this.buyBox.TabIndex = 5;
            this.buyBox.Text = "Buy";
            this.buyBox.UseVisualStyleBackColor = true;
            this.buyBox.Click += new System.EventHandler(this.buyBox_Click);
            // 
            // indexBox
            // 
            this.indexBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indexBox.Location = new System.Drawing.Point(70, 13);
            this.indexBox.Name = "indexBox";
            this.indexBox.Size = new System.Drawing.Size(100, 27);
            this.indexBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID:";
            // 
            // BuyVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buyBox);
            this.Controls.Add(this.indexBox);
            this.Controls.Add(this.label1);
            this.Name = "BuyVehicle";
            this.Size = new System.Drawing.Size(216, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buyBox;
        private System.Windows.Forms.TextBox indexBox;
        private System.Windows.Forms.Label label1;
    }
}
