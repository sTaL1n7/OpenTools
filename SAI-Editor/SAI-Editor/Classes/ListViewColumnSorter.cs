﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SAI_Editor
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;
            // Initialize the sort order to 'none'
            //OrderOfSort = SortOrder.None;
            OrderOfSort = SortOrder.Ascending;
        }  
        /// <summary>
        /// This method is inherited from the IComparer interface.
        /// It compares the two objects passed\
        /// using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal,
        /// negative if 'x' is less than 'y' and positive
        /// if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult = 0;
            ListViewItem listviewX, listviewY;
            // Cast the objects to be compared to ListViewItem objects
            listviewX = x as ListViewItem;
            listviewY = y as ListViewItem;

            if (listviewX != listviewY)
                compareResult = String.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            
            if (OrderOfSort == SortOrder.Ascending)
                return compareResult;

            return -compareResult;
        }

        /// <summary>
        /// Gets or sets the number of the column to which
        /// to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }
        /// <summary>
        /// Gets or sets the order of sorting to apply
        /// (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}
