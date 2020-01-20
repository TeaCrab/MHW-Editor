﻿namespace MHW_Editor.Gems {
    public partial class Gem : MhwItem, IMhwItem {
        public const int GEM_SIZE = 28;
        public const int GEM_OFFSET_INITIAL = 10;
        public const int GEM_OFFSET_BETWEEN = GEM_SIZE;

        public ushort Unknown1 {
            get => GetData<ushort>(Offsets.UNKNOWN1);
            set => SetData(Offsets.UNKNOWN1, value);
        }
        public byte Unknown3 {
            get => GetData<byte>(Offsets.UNKNOWN3);
            set => SetData(Offsets.UNKNOWN3, value);
        }
        public byte Unknown4 {
            get => GetData<byte>(Offsets.UNKNOWN4);
            set => SetData(Offsets.UNKNOWN4, value);
        }
        public ushort Unknown5 {
            get => GetData<ushort>(Offsets.UNKNOWN5);
            set => SetData(Offsets.UNKNOWN5, value);
        }
        public byte Unknown7 {
            get => GetData<byte>(Offsets.UNKNOWN7);
            set => SetData(Offsets.UNKNOWN7, value);
        }
        public byte Unknown8 {
            get => GetData<byte>(Offsets.UNKNOWN8);
            set => SetData(Offsets.UNKNOWN8, value);
        }
        public byte Size {
            get => GetData<byte>(Offsets.SIZE);
            set => SetData(Offsets.SIZE, value);
        }
        public byte Unknown10 {
            get => GetData<byte>(Offsets.UNKNOWN10);
            set => SetData(Offsets.UNKNOWN10, value);
        }
        public byte Unknown11 {
            get => GetData<byte>(Offsets.UNKNOWN11);
            set => SetData(Offsets.UNKNOWN11, value);
        }
        public byte Unknown12 {
            get => GetData<byte>(Offsets.UNKNOWN12);
            set => SetData(Offsets.UNKNOWN12, value);
        }
        public string Skill1 {
            get => Skills.GetName(GetData<ushort>(Offsets.SKILL1_ID));
            set => SetData(Offsets.SKILL1_ID, Skills.ToUShort(value));
        }
        public byte Unknown14 {
            get => GetData<byte>(Offsets.UNKNOWN14);
            set => SetData(Offsets.UNKNOWN14, value);
        }
        public byte Unknown15 {
            get => GetData<byte>(Offsets.UNKNOWN15);
            set => SetData(Offsets.UNKNOWN15, value);
        }
        public byte Unknown16 {
            get => GetData<byte>(Offsets.UNKNOWN16);
            set => SetData(Offsets.UNKNOWN16, value);
        }
        public byte Skill1Level {
            get => GetData<byte>(Offsets.SKILL1_LEVEL);
            set => SetData(Offsets.SKILL1_LEVEL, value);
        }
        public byte Unknown18 {
            get => GetData<byte>(Offsets.UNKNOWN18);
            set => SetData(Offsets.UNKNOWN18, value);
        }
        public byte Unknown19 {
            get => GetData<byte>(Offsets.UNKNOWN19);
            set => SetData(Offsets.UNKNOWN19, value);
        }
        public byte Unknown20 {
            get => GetData<byte>(Offsets.UNKNOWN20);
            set => SetData(Offsets.UNKNOWN20, value);
        }
        public string Skill2 {
            get => Skills.GetName(GetData<ushort>(Offsets.SKILL2_ID));
            set => SetData(Offsets.SKILL2_ID, Skills.ToUShort(value));
        }
        public byte Unknown22 {
            get => GetData<byte>(Offsets.UNKNOWN22);
            set => SetData(Offsets.UNKNOWN22, value);
        }
        public byte Unknown23 {
            get => GetData<byte>(Offsets.UNKNOWN23);
            set => SetData(Offsets.UNKNOWN23, value);
        }
        public byte Unknown24 {
            get => GetData<byte>(Offsets.UNKNOWN24);
            set => SetData(Offsets.UNKNOWN24, value);
        }
        public byte Skill2Level {
            get => GetData<byte>(Offsets.SKILL2_LEVEL);
            set => SetData(Offsets.SKILL2_LEVEL, value);
        }
        public byte Unknown26 {
            get => GetData<byte>(Offsets.UNKNOWN26);
            set => SetData(Offsets.UNKNOWN26, value);
        }
        public byte Unknown27 {
            get => GetData<byte>(Offsets.UNKNOWN27);
            set => SetData(Offsets.UNKNOWN27, value);
        }
        public byte Unknown28 {
            get => GetData<byte>(Offsets.UNKNOWN28);
            set => SetData(Offsets.UNKNOWN28, value);
        }

        public Gem(byte[] bytes, int offset) : base(bytes, offset) {
        }

        public static class Offsets {
            public const int UNKNOWN1 = 0;
            public const int UNKNOWN2 = 1;
            public const int UNKNOWN3 = 2;
            public const int UNKNOWN4 = 3;
            public const int UNKNOWN5 = 4;
            public const int UNKNOWN6 = 5;
            public const int UNKNOWN7 = 6;
            public const int UNKNOWN8 = 7;
            public const int SIZE = 8;
            public const int UNKNOWN10 = 9;
            public const int UNKNOWN11 = 10;
            public const int UNKNOWN12 = 11;
            public const int SKILL1_ID = 12;
            public const int UNKNOWN14 = 13;
            public const int UNKNOWN15 = 14;
            public const int UNKNOWN16 = 15;
            public const int SKILL1_LEVEL = 16;
            public const int UNKNOWN18 = 17;
            public const int UNKNOWN19 = 18;
            public const int UNKNOWN20 = 19;
            public const int SKILL2_ID = 20;
            public const int UNKNOWN22 = 21;
            public const int UNKNOWN23 = 22;
            public const int UNKNOWN24 = 23;
            public const int SKILL2_LEVEL = 24;
            public const int UNKNOWN26 = 25;
            public const int UNKNOWN27 = 26;
            public const int UNKNOWN28 = 27;
        }
    }
}