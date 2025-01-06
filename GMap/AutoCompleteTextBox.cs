using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmap
{
    public class AutoCompleteTextBox:TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private IEnumerable _values;
        private string _displaymember;
        private string _valuemember;
        private String _formerValue = String.Empty;
        private float _dropDownFontSize = 12f; // 預設字體大小
        public EventHandler<string> _onTextChanged;
        public EventHandler<object> _getPlaceId;
        public string _placeId;
        public float DropDownFontSize
        {
            get => _dropDownFontSize;
            set
            {
                _dropDownFontSize = value;
                if (_listBox != null)
                {
                    _listBox.Font = new Font(_listBox.Font.FontFamily, _dropDownFontSize);
                }
            }
        }
        public AutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
        }

        private void InitializeComponent()
        {
            this._listBox = new ListBox();
            this.SuspendLayout();

            this._listBox.ItemHeight = 20;

            KeyDown += this_KeyDown;
            _listBox.DoubleClick += new System.EventHandler(this.ListBoxDouble_Click);
            this.ResumeLayout(false);

        }

        private void ListBoxDouble_Click(object sender, EventArgs e)
        {
            if (_listBox.Visible)
            {
                var selecteditem_dismem = _listBox.SelectedItem.GetType().GetProperty(_displaymember);
                this.Text = (selecteditem_dismem.GetValue(_listBox.SelectedItem)).ToString();
                _getPlaceId.Invoke(this, this.Text);
                ResetListBox();
                
            }
        }

        private void ShowListBox()
        {
            if (!_isAdded && Parent != null)
            {
                Parent.Controls.Add(_listBox);
                _listBox.Left = Left;
                _listBox.Top = Top + Height;
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
                //case Keys.Tab:
                //    {
                //        if (_listBox.Visible)
                //        {
                            
                //            _getPlaceId.Invoke(this, _listBox.SelectedValue);
                //            ResetListBox();
                            
                //        }
                //        break;
                //    }
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
                case Keys.Tab:
                case Keys.Enter:
                    {
                        if (_listBox.Visible)
                        {
                            var selecteditem_dismem = _listBox.SelectedItem.GetType().GetProperty(_displaymember);
                            this.Text = (selecteditem_dismem.GetValue(_listBox.SelectedItem)).ToString();
                            var selecteditem_value = _listBox.SelectedItem.GetType().GetProperty(_valuemember);
                            _placeId = (selecteditem_value.GetValue(_listBox.SelectedItem)).ToString();
                            _getPlaceId.Invoke(this, _placeId);
                            ResetListBox();
                            _formerValue = Text;
                          
                        }
                        break;
                    }
            }
        }
       
        private void UpdateListBox()
        {
            if (Text == _formerValue) return;

            _formerValue = Text;
            _listBox.DataSource = _values;
            _listBox.DisplayMember = "Name";
            _listBox.ValueMember = "Id";
            ShowListBox();
            _listBox.Width = this.Size.Width;

            //String word = GetWord();

            //if (_values != null && word.Length > 0)
            //{                          
            //    ShowListBox();
            //    _listBox.Font = new Font(_listBox.Font.FontFamily, _dropDownFontSize);
            //    // 設定 ListBox 的寬度與 AutoCompleteTextBox 相同
            //    _listBox.Width = this.Width;

            //    using (Graphics graphics = _listBox.CreateGraphics())
            //    {
            //        for (int i = 0; i < _listBox.Items.Count; i++)
            //        {
            //            _listBox.Height += _listBox.GetItemHeight(i);
            //        }
            //    }
            //}
            //else
            //{
            //    ResetListBox();
            //}
        }
        public object DataSource
        {
            get
            {
                return _values;
            }
            set
            {                
                _values = (IEnumerable)value;
                UpdateListBox();
            }
        }

        public string DisplayMember
        {
            get
            {
                return _displaymember;
            }
            set
            {
                _displaymember = value;
                _listBox.DisplayMember = value;
            }
        }

        public string ValueMember
        {
            get
            {
                return _valuemember;
            }
            set {
                _valuemember = value; 
                _listBox.ValueMember = value;
            }
        }

        public string GetPlaceId()
        {
            return "place_id:"+_placeId;
        }

    }

}

