namespace Arena_Admin
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnPersonagens = new System.Windows.Forms.Button();
            this.lblPersonagens = new System.Windows.Forms.Label();
            this.btnMonstros = new System.Windows.Forms.Button();
            this.lblMonstros = new System.Windows.Forms.Label();
            this.dtgPersonagens = new System.Windows.Forms.DataGridView();
            this.dtgMonstros = new System.Windows.Forms.DataGridView();
            this.txtPesquisarPersonagem = new System.Windows.Forms.TextBox();
            this.txtPesquisarMonstro = new System.Windows.Forms.TextBox();
            this.Foto_Personagem = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nome_Personagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao_Personagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Personagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Foto_Monstro = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nome_Monstro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao_Monstro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Monstro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPersonagens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonstros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPersonagens
            // 
            this.btnPersonagens.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPersonagens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonagens.Font = new System.Drawing.Font("MS Reference Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonagens.Location = new System.Drawing.Point(12, 12);
            this.btnPersonagens.Name = "btnPersonagens";
            this.btnPersonagens.Size = new System.Drawing.Size(506, 100);
            this.btnPersonagens.TabIndex = 0;
            this.btnPersonagens.Text = "Controle de Personagens";
            this.btnPersonagens.UseVisualStyleBackColor = false;
            this.btnPersonagens.Click += new System.EventHandler(this.btnPersonagem_Click);
            // 
            // lblPersonagens
            // 
            this.lblPersonagens.AutoSize = true;
            this.lblPersonagens.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonagens.Location = new System.Drawing.Point(12, 285);
            this.lblPersonagens.Name = "lblPersonagens";
            this.lblPersonagens.Size = new System.Drawing.Size(266, 26);
            this.lblPersonagens.TabIndex = 2;
            this.lblPersonagens.Text = "Pesquisar Personagens:";
            // 
            // btnMonstros
            // 
            this.btnMonstros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnMonstros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonstros.Font = new System.Drawing.Font("MS Reference Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonstros.Location = new System.Drawing.Point(524, 12);
            this.btnMonstros.Name = "btnMonstros";
            this.btnMonstros.Size = new System.Drawing.Size(472, 100);
            this.btnMonstros.TabIndex = 1;
            this.btnMonstros.Text = "Controle de Monstros";
            this.btnMonstros.UseVisualStyleBackColor = false;
            this.btnMonstros.Click += new System.EventHandler(this.btnMonstros_Click);
            // 
            // lblMonstros
            // 
            this.lblMonstros.AutoSize = true;
            this.lblMonstros.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonstros.Location = new System.Drawing.Point(520, 285);
            this.lblMonstros.Name = "lblMonstros";
            this.lblMonstros.Size = new System.Drawing.Size(227, 26);
            this.lblMonstros.TabIndex = 5;
            this.lblMonstros.Text = "Pesquisar Monstros:";
            // 
            // dtgPersonagens
            // 
            this.dtgPersonagens.AllowUserToAddRows = false;
            this.dtgPersonagens.AllowUserToDeleteRows = false;
            this.dtgPersonagens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPersonagens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Foto_Personagem,
            this.Nome_Personagem,
            this.Descricao_Personagem,
            this.Id_Personagem});
            this.dtgPersonagens.Location = new System.Drawing.Point(12, 321);
            this.dtgPersonagens.Name = "dtgPersonagens";
            this.dtgPersonagens.ReadOnly = true;
            this.dtgPersonagens.RowHeadersVisible = false;
            this.dtgPersonagens.RowHeadersWidth = 75;
            this.dtgPersonagens.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgPersonagens.RowTemplate.Height = 75;
            this.dtgPersonagens.Size = new System.Drawing.Size(506, 228);
            this.dtgPersonagens.TabIndex = 10;
            // 
            // dtgMonstros
            // 
            this.dtgMonstros.AllowUserToAddRows = false;
            this.dtgMonstros.AllowUserToDeleteRows = false;
            this.dtgMonstros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMonstros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Foto_Monstro,
            this.Nome_Monstro,
            this.Descricao_Monstro,
            this.Id_Monstro});
            this.dtgMonstros.Location = new System.Drawing.Point(524, 321);
            this.dtgMonstros.Name = "dtgMonstros";
            this.dtgMonstros.ReadOnly = true;
            this.dtgMonstros.RowHeadersVisible = false;
            this.dtgMonstros.RowHeadersWidth = 75;
            this.dtgMonstros.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgMonstros.RowTemplate.Height = 75;
            this.dtgMonstros.Size = new System.Drawing.Size(472, 228);
            this.dtgMonstros.TabIndex = 11;
            // 
            // txtPesquisarPersonagem
            // 
            this.txtPesquisarPersonagem.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisarPersonagem.Location = new System.Drawing.Point(272, 282);
            this.txtPesquisarPersonagem.Name = "txtPesquisarPersonagem";
            this.txtPesquisarPersonagem.Size = new System.Drawing.Size(242, 33);
            this.txtPesquisarPersonagem.TabIndex = 12;
            this.txtPesquisarPersonagem.TextChanged += new System.EventHandler(this.txtPesquisarPersonagem_TextChanged);
            // 
            // txtPesquisarMonstro
            // 
            this.txtPesquisarMonstro.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisarMonstro.Location = new System.Drawing.Point(741, 282);
            this.txtPesquisarMonstro.Name = "txtPesquisarMonstro";
            this.txtPesquisarMonstro.Size = new System.Drawing.Size(255, 33);
            this.txtPesquisarMonstro.TabIndex = 13;
            this.txtPesquisarMonstro.TextChanged += new System.EventHandler(this.txtPesquisarMonstro_TextChanged);
            // 
            // Foto_Personagem
            // 
            this.Foto_Personagem.DataPropertyName = "Foto";
            this.Foto_Personagem.Frozen = true;
            this.Foto_Personagem.HeaderText = "Foto";
            this.Foto_Personagem.Name = "Foto_Personagem";
            this.Foto_Personagem.ReadOnly = true;
            this.Foto_Personagem.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Foto_Personagem.Width = 75;
            // 
            // Nome_Personagem
            // 
            this.Nome_Personagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome_Personagem.DataPropertyName = "Nome";
            this.Nome_Personagem.HeaderText = "Nome";
            this.Nome_Personagem.Name = "Nome_Personagem";
            this.Nome_Personagem.ReadOnly = true;
            // 
            // Descricao_Personagem
            // 
            this.Descricao_Personagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao_Personagem.DataPropertyName = "Descricao";
            this.Descricao_Personagem.HeaderText = "Descrição";
            this.Descricao_Personagem.Name = "Descricao_Personagem";
            this.Descricao_Personagem.ReadOnly = true;
            // 
            // Id_Personagem
            // 
            this.Id_Personagem.DataPropertyName = "Id";
            this.Id_Personagem.HeaderText = "Id";
            this.Id_Personagem.Name = "Id_Personagem";
            this.Id_Personagem.ReadOnly = true;
            this.Id_Personagem.Width = 40;
            // 
            // Foto_Monstro
            // 
            this.Foto_Monstro.DataPropertyName = "Foto";
            this.Foto_Monstro.Frozen = true;
            this.Foto_Monstro.HeaderText = "Foto";
            this.Foto_Monstro.Name = "Foto_Monstro";
            this.Foto_Monstro.ReadOnly = true;
            this.Foto_Monstro.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Foto_Monstro.Width = 75;
            // 
            // Nome_Monstro
            // 
            this.Nome_Monstro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome_Monstro.DataPropertyName = "Nome";
            this.Nome_Monstro.HeaderText = "Nome";
            this.Nome_Monstro.Name = "Nome_Monstro";
            this.Nome_Monstro.ReadOnly = true;
            // 
            // Descricao_Monstro
            // 
            this.Descricao_Monstro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao_Monstro.DataPropertyName = "Descricao";
            this.Descricao_Monstro.HeaderText = "Descrição";
            this.Descricao_Monstro.Name = "Descricao_Monstro";
            this.Descricao_Monstro.ReadOnly = true;
            // 
            // Id_Monstro
            // 
            this.Id_Monstro.DataPropertyName = "Id";
            this.Id_Monstro.HeaderText = "Id";
            this.Id_Monstro.Name = "Id_Monstro";
            this.Id_Monstro.ReadOnly = true;
            this.Id_Monstro.Width = 40;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.txtPesquisarMonstro);
            this.Controls.Add(this.txtPesquisarPersonagem);
            this.Controls.Add(this.dtgMonstros);
            this.Controls.Add(this.dtgPersonagens);
            this.Controls.Add(this.lblMonstros);
            this.Controls.Add(this.btnMonstros);
            this.Controls.Add(this.lblPersonagens);
            this.Controls.Add(this.btnPersonagens);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPersonagens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMonstros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPersonagens;
        private System.Windows.Forms.Label lblPersonagens;
        private System.Windows.Forms.Button btnMonstros;
        private System.Windows.Forms.Label lblMonstros;
        private System.Windows.Forms.DataGridView dtgPersonagens;
        private System.Windows.Forms.DataGridView dtgMonstros;
        private System.Windows.Forms.TextBox txtPesquisarPersonagem;
        private System.Windows.Forms.TextBox txtPesquisarMonstro;
        private System.Windows.Forms.DataGridViewImageColumn Foto_Personagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_Personagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao_Personagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Personagem;
        private System.Windows.Forms.DataGridViewImageColumn Foto_Monstro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_Monstro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao_Monstro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Monstro;
    }
}

