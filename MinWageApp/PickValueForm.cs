using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinWageApp;

namespace MinWageApp {
    public partial class PickValueForm : Form {
        public bool Accept;
        public List<SimInput> SimList;
        
        public PickValueForm() {
            InitializeComponent();
        }


        private void btnOk_Click(object sender, EventArgs e) {
            Accept = true;
            Close();
        }

        private void PickValueForm_Load(object sender, EventArgs e) {
            Accept = false;
        }

        private void PickValueForm_Shown(object sender, EventArgs e) {
            Accept = false;
        }
    }
}
