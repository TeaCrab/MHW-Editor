﻿using System.Collections.Generic;
using MHW_Generator.Models;
using MHW_Template;
using MHW_Template.Struct_Generation.Multi;

namespace MHW_Generator.Weapons {
    public class Wp09Param : WpParamBase, IMultiStruct {
        private const string N = "09";

        public MultiStruct Generate() { // .w09p
            var structs = new List<MhwMultiStructData.StructData>();
            structs.AddRange(CreateBase(N));

            var unkCbArr = new List<MhwMultiStructData.Entry> {
                new MhwMultiStructData.Entry("Unk 1", typeof(float)),
                new MhwMultiStructData.Entry("Unk 2", typeof(float)),
                new MhwMultiStructData.Entry("Unk 3", typeof(float)),
                new MhwMultiStructData.Entry("Unk 4", typeof(float))
            };

            structs.AddRange(new List<MhwMultiStructData.StructData> {
                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(uint)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(uint)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry("Charge to Reach Yellow Phial", typeof(byte)),
                    new MhwMultiStructData.Entry("Charge to Reach Red Phial", typeof(byte)),
                    new MhwMultiStructData.Entry($"Unk {unkIndex += 3}", typeof(byte)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(byte)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(byte)),
                    new MhwMultiStructData.Entry("Overcharged Phial", typeof(byte)),
                    new MhwMultiStructData.Entry($"Unk {unkIndex += 2}", typeof(byte)),
                    new MhwMultiStructData.Entry("Axe Mode Damage Multiplier", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {unkIndex += 2}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry("Elemental Phial Damage Multiplier (Not for SAED)", typeof(float)),
                    new MhwMultiStructData.Entry("Phial Duration", typeof(float)),
                    new MhwMultiStructData.Entry("Shield Charge Guard Threshold Bonus", typeof(byte)),
                    new MhwMultiStructData.Entry($"Unk {unkIndex += 4}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry("Sword Charge Duration", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {unkIndex += 2}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Action Param {++actionParamIndex}", actionParam, 1),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Unk Arr {++arrayIndex}", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry("Unk 1", typeof(float)),
                    new MhwMultiStructData.Entry("Unk 2", typeof(float)),
                    new MhwMultiStructData.Entry("Unk 3", typeof(float)),
                    new MhwMultiStructData.Entry("Unk 4", typeof(byte), enumReturn: typeof(bool)),
                    new MhwMultiStructData.Entry("Unk 5", typeof(float))
                }, 4),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Action Param {++actionParamIndex}", actionParam, 1),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Action Param {++actionParamIndex}", actionParam, 1),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Action Param {++actionParamIndex}", actionParam, 1),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Unk Arr {++arrayIndex}", unkCbArr, 21),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Unk Arr {++arrayIndex}", unkCbArr, 1),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Unk Arr {++arrayIndex}", unkCbArr, 2),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Unk Arr {++arrayIndex}", unkCbArr, 3),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Unk Arr {++arrayIndex}", unkCbArr, 4),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Unk Arr {++arrayIndex}", unkCbArr, 5),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Unk Arr {++arrayIndex}", unkCbArr, 6),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true),

                new MhwMultiStructData.StructData($"Action Param {++actionParamIndex}", actionParam, 1),

                new MhwMultiStructData.StructData($"W{N}p Params ({++paramIndex})", new List<MhwMultiStructData.Entry> {
                    new MhwMultiStructData.Entry("Savage Axe Duration (Elemental Phial)", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {unkIndex += 2}", typeof(float)),
                    new MhwMultiStructData.Entry("Savage Axe Duration Multiplier (Impact Phial)", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {unkIndex += 2}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(uint)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float)),
                    new MhwMultiStructData.Entry($"Unk {++unkIndex}", typeof(float))
                }, 1, showVertically: true)
            });

            return new MultiStruct("MHW_Editor.Weapons", $"Wp{N}Param", new MhwMultiStructData(structs, $"w{N}p", EncryptionKeys.FILE_EXT_KEY_LOOKUP[$".w{N}p"]));
        }
    }
}