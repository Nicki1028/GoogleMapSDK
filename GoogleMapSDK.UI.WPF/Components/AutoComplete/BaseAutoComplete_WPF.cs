using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using GoogleMapSDK.UI.WPF.Extensions;
using System.Windows.Controls.Primitives;
using static GoogleMapSDK.UI.Contract.Components.AutoComplete.AutoCompleteContract;

namespace GoogleMapSDK.UI.WPF.Components.AutoComplete
{
    public abstract class BaseAutoComplete<T, T2> : TextBox, IAutoCompleteView
    {
        private Popup _popup;
        protected ListBox _listBox;
        protected bool _isAdded;
        protected IEnumerable _values;
        protected string _displaymember = "Key";
        protected string _valuemember = "Value";
        public virtual string DisplayMember
        {
            get { return _displaymember; }
            set { _displaymember = value; }
        }
        public virtual string ValueMember
        {
            get { return _valuemember; }
            set { _valuemember = value; }
        }

        protected String _formerValue = String.Empty;
        protected float _dropDownFontSize = 12f; 
        public float DropDownFontSize
        {
            get => _dropDownFontSize;
            set
            {
                _dropDownFontSize = value;
                if (_listBox != null)
                {
                    _listBox.FontFamily = new FontFamily(_listBox.FontFamily.Source); 
                    _listBox.FontSize = _dropDownFontSize; 
                }
            }
        }
        protected abstract Task<IEnumerable<T>> GetCompleteSourceAsync(string input);
        protected abstract Task<T2> GetSelectItemAsync(string selectedItem);

        public event EventHandler<T2> OnSelectItem;
        public BaseAutoComplete()
        {
            InitializeComponent();
            ResetListBox();
        }

        public void InitializeComponent()
        {
          
            this._listBox = new ListBox();          
            this._listBox.ItemContainerStyle = new Style(typeof(ListBoxItem))
            {
                Setters = { new Setter(FrameworkElement.HeightProperty, 20.0) }
            };

            // 創建 Popup
            _popup = new Popup
            {
                PlacementTarget = this, // 綁定到 TextBox 本身
                Placement = PlacementMode.Bottom, // 設置位置為下方
                StaysOpen = false, // 點擊外部時自動關閉
                Child = _listBox // 將 ListBox 作為 Popup 的內容
            };

            this.KeyDown += AutoComplete_KeyDown;
            this._listBox.MouseDoubleClick += BaseAutoComplete_ItemSelectedAsync;
            this.KeyUp += AutoCompelte_KeyUp;
        }

        private async void AutoComplete_KeyDown(object sender, KeyEventArgs e)
        {
            await this.AutoComplete_KeyDown(sender, (ConsoleKey)e.Key);
        }

        private void AutoCompelte_KeyUp(object sender, KeyEventArgs e)
        {
            this.AutoCompelte_KeyUp(sender, (ConsoleKey)e.Key);
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
            _listBox.Visibility = Visibility.Collapsed;
            _popup.IsOpen = false;
        }
        public void UpdateListBox()
        {
            if (Text == _formerValue) return;

            _formerValue = Text;
            _listBox.ItemsSource = _values;
            _listBox.DisplayMemberPath = DisplayMember;
            _listBox.SelectedValuePath = ValueMember;
            ShowListBox();
            _listBox.Width = this.ActualWidth;
        }
        public void ShowListBox()
        {
            if (!_isAdded && this.Parent is Panel parentPanel)
            {
                
                _isAdded = true;
            }
            _popup.IsOpen = true;
            _listBox.Visibility = Visibility.Visible;
            // WPF 中的 BringToFront 等效處理
            _listBox.Focus();
        }


        public void AutoCompelte_KeyUp(object sender, ConsoleKey key)
        {
            this.Timerextention((async () =>
            {
                this.DataSource = await this.GetCompleteSourceAsync(this.Text);
            }));
        }

        public async Task AutoComplete_KeyDown(object sender, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    {
                        if ((_listBox.Visibility == Visibility.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        if ((_listBox.Visibility == Visibility.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;
                        break;
                    }
                case ConsoleKey.Tab:
                case ConsoleKey.Enter:
                    {
                        if (_listBox.Visibility == Visibility.Visible)
                        {

                            var selecteditem_dismem = _listBox.SelectedItem.GetType().GetProperty(_displaymember);
                            this.Text = (selecteditem_dismem.GetValue(_listBox.SelectedItem)).ToString();
                            _formerValue = Text;
                            T2 t2 = await GetSelectItemAsync(_listBox.SelectedValue.ToString());
                            OnSelectItem?.Invoke(this, t2);
                            ResetListBox();
                        }
                        break;
                    }
            }
        }

        public async void BaseAutoComplete_ItemSelectedAsync(object sender, EventArgs e)
        {
            if (_listBox.Visibility == Visibility.Visible)
            {
                var selecteditem_dismem = _listBox.SelectedItem.GetType().GetProperty(_displaymember);
                this.Text = (selecteditem_dismem.GetValue(_listBox.SelectedItem)).ToString();
                T2 t2 = await GetSelectItemAsync(_listBox.SelectedValue.ToString());
                OnSelectItem?.Invoke(this, t2);
                ResetListBox();
            }
        }
    }
}
