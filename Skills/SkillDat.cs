﻿using System;
using System.ComponentModel;
using MHW_Editor.Assets;
using MHW_Editor.Models;

namespace MHW_Editor.Skills {
    public partial class SkillDat : MhwItem {
        public static readonly SkillDat DEFAULT = new SkillDat(new byte[0], 0);

        public SkillDat(byte[] bytes, ulong offset) : base(bytes, offset) {
        }

        [SortOrder(0)]
        [DisplayName("Name/Id")]
        [CustomSorter(typeof(SkillDatNameIdSorter))]
        public IdNamePair Name_And_Id => DataHelper.skillData[MainWindow.locale][Id];

        public override string Name => "None";

        [SortOrder(Param_8_sortIndex + 1)]
        public string Description => DataHelper.skillDataDescriptions[MainWindow.locale][Id];
    }

    public class SkillDatNameIdSorter : ICustomSorter {
        public ListSortDirection SortDirection { get; set; } = ListSortDirection.Ascending;

        public int Compare(object x, object y) {
            if (x is SkillDat x1 && y is SkillDat x2) {
                if (MainWindow.showIdBeforeName) {
                    var idCompare = x1.Name_And_Id.id.CompareTo(x2.Name_And_Id.id) * (SortDirection == ListSortDirection.Ascending ? 1 : -1);
                    var levelCompare = x1.Level.CompareTo(x2.Level) * (SortDirection == ListSortDirection.Ascending ? 1 : -1);

                    return idCompare == 0 ? levelCompare : idCompare;
                } else {
                    var nameCompare = string.Compare(x1.Name_And_Id.name, x2.Name_And_Id.name, StringComparison.Ordinal) * (SortDirection == ListSortDirection.Ascending ? 1 : -1);
                    var levelCompare = x1.Level.CompareTo(x2.Level) * (SortDirection == ListSortDirection.Ascending ? 1 : -1);

                    return nameCompare == 0 ? levelCompare : nameCompare;
                }
            }

            return 0;
        }
    }
}