using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;
namespace TVSReports
{
    class clsReports
    {

        #region MakeSameHeight
        public float MakeSameHeight(object objObject)
        {
            return MakeSameHeight(objObject, null);
        }

        public float MakeSameHeight(object objObject, object sngHeight)
        {
            float single1 = default(float);
            int i1 = default(int);
            float single2 = default(float);
            Exception exception1 = default(Exception);
            object[] objectArray1 = default(object[]);
            int i2 = default(int);
            object[] objectArray2 = default(object[]);
            bool[] booleanArray1 = default(bool[]);
            object[] objectArray3 = default(object[]);
            object[] objectArray4 = default(object[]);
            bool[] booleanArray2 = default(bool[]);
            object[] objectArray5 = default(object[]);
            object[] objectArray6 = default(object[]);
            bool[] booleanArray3 = default(bool[]);
            int i3 = default(int);
            bool b1 = default(bool);
            bool b2 = default(bool);
            int i4 = default(int);

            try
            {
                b1 = (objObject == null);
                if (!b1)
                {
                    goto L_0013;
                }
                goto L_0386;

            L_0013:
                {
                }
                objectArray1 = new object[1];
                objectArray1[0] = true;
                NewLateBinding.LateSet(objObject, ((Type)null), "KeepTogether", objectArray1, ((string[])null), ((Type[])null));
                b1 = (sngHeight != null);
                if (!b1)
                {
                    goto L_005A;
                }
                single2 = Conversions.ToSingle(sngHeight);
                goto L_0222;

            L_005A:
                {
                }
                i2 = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(NewLateBinding.LateGet(objObject, ((Type)null), "Controls", new object[0], ((string[])null), ((Type[])null), ((bool[])null)), ((Type)null), "Count", new object[0], ((string[])null), ((Type[])null), ((bool[])null)), 1));
                i1 = 0;
                goto L_0216;

            L_009E:
                {
                }
                objectArray1 = new object[1];
                objectArray1[0] = i1;
                objectArray2 = objectArray1;
                booleanArray1 = new bool[1];
                booleanArray1[0] = true;
                if (!booleanArray1[0])
                {
                    goto L_00FE;
                }
                i1 = ((int)Conversions.ChangeType(objectArray2[0], typeof(int)));

            L_00FE:
                {
                }
                b1 = (NewLateBinding.LateGet(objObject, ((Type)null), "Controls", objectArray2, ((string[])null), ((Type[])null), booleanArray1) is DataDynamics.ActiveReports.TextBox);
                if (!b1)
                {
                    goto L_0210;
                }
                objectArray3 = new object[1];
                objectArray3[0] = i1;
                objectArray4 = objectArray3;
                booleanArray2 = new bool[1];
                booleanArray2[0] = true;
                if (!booleanArray2[0])
                {
                    goto L_016F;
                }
                i1 = ((int)Conversions.ChangeType(objectArray4[0], typeof(int)));

            L_016F:
                {
                }
                b2 = Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(NewLateBinding.LateGet(objObject, ((Type)null), "Controls", objectArray4, ((string[])null), ((Type[])null), booleanArray2), ((Type)null), "Height", new object[0], ((string[])null), ((Type[])null), ((bool[])null)), single2, false);
                if (!b2)
                {
                    goto L_020F;
                }
                objectArray5 = new object[1];
                objectArray5[0] = i1;
                objectArray6 = objectArray5;
                booleanArray3 = new bool[1];
                booleanArray3[0] = true;
                if (!booleanArray3[0])
                {
                    goto L_01F5;
                }
                i1 = ((int)Conversions.ChangeType(objectArray6[0], typeof(int)));

            L_01F5:
                {
                }
                single2 = Conversions.ToSingle(NewLateBinding.LateGet(NewLateBinding.LateGet(objObject, ((Type)null), "Controls", objectArray6, ((string[])null), ((Type[])null), booleanArray3), ((Type)null), "Height", new object[0], ((string[])null), ((Type[])null), ((bool[])null)));

            L_020F:
                {
                }

            L_0210:
                {
                }
                i1++;

            L_0216:
                {
                }
                i4 = i2;
                if (i1 <= i4)
                {
                    goto L_009E;
                }

            L_0222:
                {
                }
                i3 = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(NewLateBinding.LateGet(objObject, ((Type)null), "Controls", new object[0], ((string[])null), ((Type[])null), ((bool[])null)), ((Type)null), "Count", new object[0], ((string[])null), ((Type[])null), ((bool[])null)), 1));
                i1 = 0;
                goto L_0362;

            L_0266:
                {
                }
                objectArray6 = new object[1];
                objectArray6[0] = i1;
                objectArray5 = objectArray6;
                booleanArray3 = new bool[1];
                booleanArray3[0] = true;
                if (!booleanArray3[0])
                {
                    goto L_02C6;
                }
                i1 = ((int)Conversions.ChangeType(objectArray5[0], typeof(int)));

            L_02C6:
                {
                }
                b2 = (NewLateBinding.LateGet(objObject, ((Type)null), "Controls", objectArray5, ((string[])null), ((Type[])null), booleanArray3) is DataDynamics.ActiveReports.TextBox);
                if (!b2)
                {
                    goto L_035C;
                }
                objectArray4 = new object[1];
                objectArray4[0] = i1;
                objectArray3 = objectArray4;
                booleanArray2 = new bool[1];
                booleanArray2[0] = true;
                if (!booleanArray2[0])
                {
                    goto L_0337;
                }
                i1 = ((int)Conversions.ChangeType(objectArray3[0], typeof(int)));

            L_0337:
                {
                }
                objectArray2 = new object[1];
                objectArray2[0] = single2;
                NewLateBinding.LateSetComplex(NewLateBinding.LateGet(objObject, ((Type)null), "Controls", objectArray3, ((string[])null), ((Type[])null), booleanArray2), ((Type)null), "Height", objectArray2, ((string[])null), ((Type[])null), false, true);

            L_035C:
                {
                }
                i1++;

            L_0362:
                {
                }
                i4 = i3;
                if (i1 <= i4)
                {
                    goto L_0266;
                }
                single1 = single2;
            }
            catch (Exception exception2)
            {

                //L_0374:

                //    {
                //    }
                exception1 = exception2;
                throw exception1;
            }

        L_0386:
            {
            }

            //L_0385:

            //    {
            //    }
            return single1;
        }

        #endregion

     }
}
