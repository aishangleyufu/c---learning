﻿namespace ItcastCater
{
    partial class FrmBilling
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPersonCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labDeskName = new System.Windows.Forms.Label();
            this.labRoomType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbMeal = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.wads = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labLittleMoney = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGetCostsMoney = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "房间类型:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPersonCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labDeskName);
            this.groupBox1.Controls.Add(this.labRoomType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckbMeal);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.wads);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labLittleMoney);
            this.groupBox1.Location = new System.Drawing.Point(49, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 264);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "顾客开单";
            // 
            // txtPersonCount
            // 
            this.txtPersonCount.Location = new System.Drawing.Point(87, 54);
            this.txtPersonCount.Name = "txtPersonCount";
            this.txtPersonCount.Size = new System.Drawing.Size(100, 21);
            this.txtPersonCount.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "顾客人数:";
            // 
            // labDeskName
            // 
            this.labDeskName.AutoSize = true;
            this.labDeskName.Location = new System.Drawing.Point(90, 32);
            this.labDeskName.Name = "labDeskName";
            this.labDeskName.Size = new System.Drawing.Size(41, 12);
            this.labDeskName.TabIndex = 10;
            this.labDeskName.Text = "label7";
            // 
            // labRoomType
            // 
            this.labRoomType.AutoSize = true;
            this.labRoomType.Location = new System.Drawing.Point(275, 32);
            this.labRoomType.Name = "labRoomType";
            this.labRoomType.Size = new System.Drawing.Size(41, 12);
            this.labRoomType.TabIndex = 9;
            this.labRoomType.Text = "label6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "餐桌编号:";
            // 
            // ckbMeal
            // 
            this.ckbMeal.AutoSize = true;
            this.ckbMeal.Location = new System.Drawing.Point(30, 236);
            this.ckbMeal.Name = "ckbMeal";
            this.ckbMeal.Size = new System.Drawing.Size(108, 16);
            this.ckbMeal.TabIndex = 6;
            this.ckbMeal.Text = "开单后添加消费";
            this.ckbMeal.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(79, 109);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(286, 96);
            this.txtDescription.TabIndex = 4;
            // 
            // wads
            // 
            this.wads.AutoSize = true;
            this.wads.Location = new System.Drawing.Point(208, 63);
            this.wads.Name = "wads";
            this.wads.Size = new System.Drawing.Size(65, 12);
            this.wads.TabIndex = 3;
            this.wads.Text = "最低消费：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "开单备注：";
            // 
            // labLittleMoney
            // 
            this.labLittleMoney.AutoSize = true;
            this.labLittleMoney.Location = new System.Drawing.Point(276, 63);
            this.labLittleMoney.Name = "labLittleMoney";
            this.labLittleMoney.Size = new System.Drawing.Size(41, 12);
            this.labLittleMoney.TabIndex = 3;
            this.labLittleMoney.Text = "label2";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(273, 370);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(100, 30);
            this.btncancel.TabIndex = 37;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "房间计费方法：";
            // 
            // lblGetCostsMoney
            // 
            this.lblGetCostsMoney.AutoSize = true;
            this.lblGetCostsMoney.Location = new System.Drawing.Point(194, 4);
            this.lblGetCostsMoney.Name = "lblGetCostsMoney";
            this.lblGetCostsMoney.Size = new System.Drawing.Size(65, 12);
            this.lblGetCostsMoney.TabIndex = 0;
            this.lblGetCostsMoney.Text = "不计房间费";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.Controls.Add(this.lblGetCostsMoney);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(37, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 22);
            this.panel1.TabIndex = 38;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(134, 370);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 35;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(492, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmBilling";
            this.Text = "顾客开单";
            this.Load += new System.EventHandler(this.FrmBilling_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPersonCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labDeskName;
        private System.Windows.Forms.Label labRoomType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbMeal;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label wads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labLittleMoney;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGetCostsMoney;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;

    }
}