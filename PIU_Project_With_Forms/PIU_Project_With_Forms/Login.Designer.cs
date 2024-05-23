namespace PIU_Project_With_Forms
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameLoginBox = new System.Windows.Forms.TextBox();
            this.passwordLoginBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.adminLoginBox = new System.Windows.Forms.TextBox();
            this.adminLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerShowButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(221, 95);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(130, 29);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username";
            // 
            // usernameLoginBox
            // 
            this.usernameLoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLoginBox.Location = new System.Drawing.Point(357, 90);
            this.usernameLoginBox.Name = "usernameLoginBox";
            this.usernameLoginBox.Size = new System.Drawing.Size(154, 34);
            this.usernameLoginBox.TabIndex = 1;
            // 
            // passwordLoginBox
            // 
            this.passwordLoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLoginBox.Location = new System.Drawing.Point(357, 130);
            this.passwordLoginBox.Name = "passwordLoginBox";
            this.passwordLoginBox.PasswordChar = '*';
            this.passwordLoginBox.Size = new System.Drawing.Size(154, 34);
            this.passwordLoginBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(221, 135);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(124, 29);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // adminLoginBox
            // 
            this.adminLoginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminLoginBox.Location = new System.Drawing.Point(357, 170);
            this.adminLoginBox.Name = "adminLoginBox";
            this.adminLoginBox.Size = new System.Drawing.Size(154, 34);
            this.adminLoginBox.TabIndex = 5;
            // 
            // adminLabel
            // 
            this.adminLabel.AutoSize = true;
            this.adminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminLabel.Location = new System.Drawing.Point(86, 172);
            this.adminLabel.Name = "adminLabel";
            this.adminLabel.Size = new System.Drawing.Size(265, 29);
            this.adminLabel.TabIndex = 4;
            this.adminLabel.Text = "Admin Code (optional)";
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(357, 210);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(121, 37);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // registerShowButton
            // 
            this.registerShowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerShowButton.Location = new System.Drawing.Point(357, 253);
            this.registerShowButton.Name = "registerShowButton";
            this.registerShowButton.Size = new System.Drawing.Size(121, 37);
            this.registerShowButton.TabIndex = 7;
            this.registerShowButton.Text = "Register";
            this.registerShowButton.UseVisualStyleBackColor = true;
            this.registerShowButton.Click += new System.EventHandler(this.registerShowButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 366);
            this.Controls.Add(this.registerShowButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.adminLoginBox);
            this.Controls.Add(this.adminLabel);
            this.Controls.Add(this.passwordLoginBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLoginBox);
            this.Controls.Add(this.usernameLabel);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameLoginBox;
        private System.Windows.Forms.TextBox passwordLoginBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox adminLoginBox;
        private System.Windows.Forms.Label adminLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerShowButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}