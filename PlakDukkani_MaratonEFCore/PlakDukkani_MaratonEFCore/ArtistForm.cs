using PlakDukkani_MaratonEFCore.DAL.Context;
using PlakDukkani_MaratonEFCore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlakDukkani_MaratonEFCore
{
    public partial class ArtistForm : Form
    {
        public ArtistForm()
        {
            InitializeComponent();
        }

        private void ArtistForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            int artistId = Convert.ToInt32(this.Tag);
            if (artistId > 0)
            {
                using (PlakDbContext db = new PlakDbContext())
                {
                    var artist = db.Artist.FirstOrDefault(a => a.Id == artistId);
                    if (artist != null)
                    {
                        artist.ArtistName = txtArtistName.Text;
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            this.Tag = 0;
            this.txtArtistName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {
                using (PlakDbContext db = new PlakDbContext())
                {
                    Artist artist;
                    int artistId = Convert.ToInt32(this.Tag);
                    if (artistId == 0)
                    {
                        artist = new Artist();
                        db.Artist.Add(artist);
                    }
                    else
                    {
                        artist = db.Artist.FirstOrDefault(a => a.Id == artistId);
                    }
                    if (artist != null)
                    {
                        artist.ArtistName = txtArtistName.Text;
                    }
                    db.SaveChanges();

                    this.Tag = artist.Id;
                    MessageBox.Show("işlem başarılı");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete();

        }

        private void FormDelete()
        {
            if (this.Tag != null)
            {
                var dialog = MessageBox.Show("Seçilen kaydı silmek istiyor musunuz?", "Sanatçı Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    using (PlakDbContext db = new PlakDbContext())
                    {
                        try
                        {
                            int artistId = Convert.ToInt32(this.Tag);
                            var artist = db.Artist.FirstOrDefault(c => c.Id == artistId);
                            if (artist != null)
                            {
                                db.Artist.Remove(artist);
                                db.SaveChanges();
                                MessageBox.Show("İşlem Başarılı");
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
