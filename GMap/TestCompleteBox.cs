using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmap
{
    public class TestCompleteBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private List<AutoCompleteTextBoxData> _values;
        private String _formerValue = String.Empty;
        public EventHandler<string> SelectedItem;

        public TestCompleteBox()
        {
            InitializeComponent();
            ResetListBox();
        }

        private void InitializeComponent()
        {
            this._listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _listBox
            // 
            this._listBox.ItemHeight = 20;
            this._listBox.Location = new System.Drawing.Point(0, 0);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(120, 96);
            this._listBox.TabIndex = 0;
            this._listBox.SelectedIndexChanged += new System.EventHandler(this._listBox_SelectedIndexChanged);
            this._listBox.DoubleClick += new System.EventHandler(this._listBox_DoubleClick);
            KeyDown += this_KeyDown;
            this.ResumeLayout(false);
        }

        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Parent.Controls.Add(_listBox);
                // 原版寫法，長在下面
                _listBox.Left = Left;
                _listBox.Top = Top + Height;
                //_listBox.Left = Right;
                //_listBox.Top = 0;
                _isAdded = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
        }

        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {
                            AutoCompleteTextBoxData item = (AutoCompleteTextBoxData)_listBox.SelectedItem;
                            this.Text = item.Key;
                            SendPlaceDetail(item.Value);
                            //InsertWord((String)_listBox.SelectedItem);
                            ResetListBox();
                            _formerValue = Text;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;

                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;

                        break;
                    }
            }
        }



        private void UpdateListBox()
        {
            if (Text == _formerValue) return;

            _formerValue = Text;
            _listBox.DataSource = _values;
            _listBox.DisplayMember = "Key";
            _listBox.ValueMember = "Value";
            ShowListBox();
            _listBox.Width = this.Size.Width;
        }


        public List<AutoCompleteTextBoxData> Values
        {
            get
            {
                return _values;
            }
            set

            {
                _values = value;
                UpdateListBox();
            }
        }



        private void _listBox_DoubleClick(object sender, EventArgs e)
        {
            if (_listBox.Visible)
            {
                AutoCompleteTextBoxData item = (AutoCompleteTextBoxData)_listBox.SelectedItem;
                this.Text = item.Key;
                SendPlaceDetail(item.Value);

                ResetListBox();
                _formerValue = Text;
            }
        }

        private void _listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async void SendPlaceDetail(object itemValue)
        {
            SelectedItem.Invoke(this, itemValue.ToString());
        }
    }
}
