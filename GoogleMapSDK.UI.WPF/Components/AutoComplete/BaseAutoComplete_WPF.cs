using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using GoogleMapSDK.UI.Contract.Components;
using System.Windows.Media;
using System.Windows;
using GoogleMapSDK.UI.WPF.Extensions;
using System.Windows.Controls.Primitives;

namespace GoogleMapSDK.UI.WPF.Components.AutoComplete
{
    public abstract class BaseAutoComplete<T, T2> : TextBox, AutoCompleteBase
    {
        private Popup _popup;
        protected ListBox _listBox;
        protected bool _isAdded;
        protected IEnumerable _values;
        protected string _displaymember;
        protected string _valuemember;
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
                    _listBox.FontFamily = new FontFamily(_listBox.FontFamily.Source); 
                    _listBox.FontSize = _dropDownFontSize; 
                }
            }
        }

        protected abstract Task<IEnumerable<T>> GetCompleteSourceAsync();

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
            this.DisplayMember = "Name";
            this.ValueMember = "Id";
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



            KeyDown += AutoCompleteList_KeyDown;
            _listBox.MouseDoubleClick += AutoCompleteList_ItemSelected;
            this.KeyUp += AutoCompleteList_KeyUp;
        }

        public async void AutoCompleteList_KeyDown(object sender, EventArgs e)
        {
            KeyEventArgs key = (KeyEventArgs)e;
            switch (key.Key)
            {
                case Key.Down:
                    {
                        if ((_listBox.Visibility == Visibility.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        break;
                    }
                case Key.Up:
                    {
                        if ((_listBox.Visibility == Visibility.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;
                        break;
                    }
                case Key.Tab:
                case Key.Enter:
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

        public async void AutoCompleteList_ItemSelected(object sender, EventArgs e)
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

        public void AutoCompleteList_KeyUp(object sender, EventArgs e)
        {

            this.Timerextention((async () =>
            {
                this.DataSource = await this.GetCompleteSourceAsync();
            }));
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
        public string DisplayMember
        {
            get
            {
                return _displaymember;
            }
            set
            {
                _displaymember = value;
                _listBox.DisplayMemberPath = value;
            }
        }

        public string ValueMember
        {
            get
            {
                return _valuemember;
            }
            set
            {
                _valuemember = value;
                _listBox.SelectedValuePath = value;
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
    }
}
