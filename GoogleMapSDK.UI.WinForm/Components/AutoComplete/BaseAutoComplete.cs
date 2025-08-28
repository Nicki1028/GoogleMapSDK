using GoogleMapSDK.UI.WinForm.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.UI.WinForm.Components.AutoComplete
{
    //TODO:還剩下兩個東西尚未完成:
    //1.DisplayMember需要動態處理，讓使用者可以自定義選擇的類型(或者考慮做成DTO讓內部直接轉換)
    //2.GoogleMapAPI 目前尚未解偶，因此使用者必須要寫上GoogleSign(考慮使用擴充方法去完成註冊)
    //3.IOC化,需要將所有元件都改為擁有自己的Interface與元件，並能完成註冊，讓使用者直接就可以使用
    public abstract class BaseAutoComplete<T,T2> : TextBox, IAutoCompleteView
    {
        
        protected ListBox _listBox;
        protected bool _isAdded;
        protected IEnumerable _values;
        public virtual string DisplayMember { get; } = "Key";
        public virtual string ValueMember { get;} = "Value";

        protected String _formerValue = String.Empty;
       
        protected float _dropDownFontSize = 12f; // 預設字體大小
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
        
        public event EventHandler<T2> OnSelectItem;
        protected abstract Task<IEnumerable<T>> GetCompleteSource(string input);
        protected abstract Task<T2> GetSelectItemAsync(string selectedItem);
       
        public BaseAutoComplete()
        {
            InitializeComponent();
            ResetListBox();
        }
        public void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

            this._listBox = new ListBox();
            this._listBox.ItemHeight = 20;

            this.KeyDown += BaseAutoComplete_KeyDown;
            this.KeyUp += BaseAutoComplete_KeyUp;
            this._listBox.DoubleClick += BaseAutoComplete_ItemSelectedAsync;
        }
        public async void BaseAutoComplete_ItemSelectedAsync(object sender, EventArgs e)
        {
            if (_listBox.Visible)
            {
                var selecteditem_dismem = _listBox.SelectedItem.GetType().GetProperty(DisplayMember);
                this.Text = (selecteditem_dismem.GetValue(_listBox.SelectedItem)).ToString();
                if (_listBox.SelectedValue == null) return;
                T2 t2 = await GetSelectItemAsync(_listBox.SelectedValue.ToString());
                OnSelectItem?.Invoke(this, t2);
                ResetListBox();
            }
        }
        private async void BaseAutoComplete_KeyDown(object sender, KeyEventArgs e)
        {
            await this.AutoComplete_KeyDown(sender, (ConsoleKey)e.KeyCode);
        }
        private void BaseAutoComplete_KeyUp(object sender, KeyEventArgs e)
        {
            this.AutoCompelte_KeyUp(sender, (ConsoleKey)e.KeyCode);
        }         
        public object DataSource
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value as IEnumerable;
                UpdateListBox();
            }
        }
        public void ResetListBox()
        {
            _listBox.Visible = false;
        }
        public void UpdateListBox()
        {
            if (Text == _formerValue) return;

            _formerValue = Text;
            _listBox.DisplayMember = DisplayMember;
            _listBox.ValueMember = ValueMember;
            _listBox.DataSource = _values;
            ShowListBox();
            _listBox.Width = this.Size.Width;
        }
        public void ShowListBox()
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
        public void AutoCompelte_KeyUp(object sender, ConsoleKey key)
        {
            this.Timerextention((async () =>
            {
                this.DataSource = await this.GetCompleteSource(this.Text);
            }));
        }
        public async Task AutoComplete_KeyDown(object sender, ConsoleKey key)
        {          
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;
                        break;
                    }
                case ConsoleKey.Tab:
                case ConsoleKey.Enter:
                    {
                        if (_listBox.Visible)
                        {
                            var selecteditem_dismem = _listBox.SelectedItem.GetType().GetProperty(DisplayMember);
                            this.Text = (selecteditem_dismem.GetValue(_listBox.SelectedItem)).ToString();                            
                            _formerValue = Text;
                            if (_listBox.SelectedValue == null) return;
                            T2 t2 = await GetSelectItemAsync(_listBox.SelectedValue.ToString());
                            OnSelectItem?.Invoke(this, t2);
                            ResetListBox();
                        }
                        break;
                    }
            }
        }
    }
}
