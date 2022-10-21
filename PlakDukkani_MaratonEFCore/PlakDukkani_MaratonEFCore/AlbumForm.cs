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
    public partial class AlbumForm : Form
    {
        public AlbumForm()
        {
            InitializeComponent();
        }

        private void AlbumForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillData();
            FillControl();
        }

        private void FillData()
        {
            int albumID = Convert.ToInt32(this.Tag);

            if (albumID > 0)
            {
                using (PlakDbContext db = new PlakDbContext())
                {
                    var album = db.Album.FirstOrDefault(p => p.AlbumId == albumID);
                    if (album != null)
                    {
                        txtAlbumName.Text = album.AlbumAdi;
                        dtpDate.Value = Convert.ToDateTime(album.CikisTarihi);
                        nuDiscount.Value = Convert.ToDecimal(album.IndirimOrani);
                        nuPrice.Value = Convert.ToDecimal(album.Fiyati);
                        cmbArtist.SelectedValue = album.AlbumId;
                        chkDiscontinued.Checked = album.DevamDurumu;
                    }
                }
            }
        }

        private void FillControl()
        {
            FillArtist();
        }

        private void FillArtist()
        {
            using (PlakDbContext db = new PlakDbContext())
            {
                var artistList = db.Artist.Select(a => new { Value = a.Id, Text = a.ArtistName }).ToList();
                cmbArtist.DisplayMember = "Text";
                cmbArtist.ValueMember = "Value";
                cmbArtist.DataSource = artistList;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            this.Tag = 0;
            txtAlbumName.Text = "";
            cmbArtist.SelectedValue = -1;
            dtpDate.Value = DateTime.Now;
            nuPrice.Value = 0;
            nuDiscount.Value = 0;
            chkDiscontinued.Checked = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {
                using (PlakDbContext db=new PlakDbContext())
                {
                    Album album;
                    int albumId = Convert.ToInt32(this.Tag);
                    if (albumId==0)
                    {
                        album = new Album();
                        db.Album.Add(album);
                    }
                    else
                    {
                        album = db.Album.FirstOrDefault(a => a.AlbumId == albumId);
                    }
                    if (album!=null)
                    {
                        album.AlbumAdi = txtAlbumName.Text;
                        album.CikisTarihi=dtpDate.Value;
                        album.Fiyati = nuPrice.Value;
                        album.IndirimOrani = nuDiscount.Value;
                        album.DevamDurumu = chkDiscontinued.Checked;
                        album.ArtistId = Convert.ToInt32(cmbArtist.SelectedValue);
                    }
                    db.SaveChanges();
                    this.Tag = album.AlbumId;
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
                            int albumId = Convert.ToInt32(this.Tag);
                            var album = db.Album.FirstOrDefault(c => c.AlbumId == albumId);
                            if (album != null)
                            {
                                db.Album.Remove(album);
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
