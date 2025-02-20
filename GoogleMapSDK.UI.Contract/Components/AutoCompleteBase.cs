using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.Contract.Components
{
    public interface AutoCompleteBase
    {
        //Property
        object DataSource { get; set; }
        string DisplayMember { get; }
        string ValueMember { get; }

        //Methods
        void InitializeComponent();
        void ResetListBox();
        void UpdateListBox();
        void ShowListBox();

        //Event
        void AutoCompleteList_KeyDown(object sender, EventArgs e);
        void AutoCompleteList_KeyUp(object sender, EventArgs e);
        void AutoCompleteList_ItemSelected(object sender, EventArgs e);

    }

}

