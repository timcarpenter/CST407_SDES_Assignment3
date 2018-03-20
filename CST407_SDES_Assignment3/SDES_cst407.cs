using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Collections;

namespace CST407_SDES_Assignment3
{

    public partial class SDES_Program : Form
    {
        private const int MAX_10 = 10;
        private const int MAX_8 = 8;
        private const int MAX_5 = 5;
        private const int MAX_4 = 4;
        private const int MAX_2 = 2;

        public SDES_Program()
        {
            InitializeComponent();
        }

        private void btn_Key_Click(object sender, EventArgs e)
        {

            int []p10Array = new int[MAX_10], //for Permutation 10 array
                ls1p1 = new int[MAX_5], ls1p2 = new int[MAX_5], //for 1 leftshift part 1/2
                ls2p1 = new int[MAX_5], ls2p2 = new int[MAX_5], //for 2 leftshift part 1/2
                shifted1 = new int[MAX_10], shifted2 = new int[MAX_10], //for post shift array
                p8k1 = new int[MAX_8], p8k2 = new int[MAX_8];   //for key1 and key 2

            //take in key from form
            string keyString = txtbx_Key.Text;

            int[] keyArray = new int[keyString.Length];

            for (int i = 0; i < keyString.Length; i++)
            {
                keyArray[i] = Convert.ToUInt16(keyString[i]); //index;

            }
            //keyArray = keyString.Select(int.Parse(keyString).ToArray();
            //keyArray = Array.ConvertAll(keyString, int.Parse);

            //generate Perm10 Array
            p10Array = P10(keyArray);

            //copy 5 bits into 1st array, coppy 5 bits into 2nd array
            for (int i = 0; i < 5; i++)
            {
                ls1p1[i] = p10Array[i];
            }

            for (int i = 0,j=5; j < 10; i++,j++)
            {
                ls1p2[i] = p10Array[j];
            }

            //left shift both 5 bit arrays - key1 and key2
            ls1p1 = Circular_left_shift(ls1p1);
            ls1p2 = Circular_left_shift(ls1p2);
            //arrays are good from here...

            //2leftshift for 5 bit arrays - key 2
            ls2p1 = Circular_two_left_shift(ls1p1);
            ls2p2 = Circular_two_left_shift(ls1p2);
            //arrays are good from here...

            //Concatenate the two 5bit arrays back together
            shifted1 = ls1p1.Concat(ls1p2).ToArray();
            shifted2 = ls2p1.Concat(ls2p2).ToArray();
            //arrays are good from here...

            //run shifted array into 8 bit permutation
            p8k1 = kP8(shifted1);
            p8k2 = kP8(shifted2);

            //Convert from array to string
            StringBuilder k1 = new StringBuilder();
            StringBuilder k2 = new StringBuilder();

            //copy array to string
            for (int x = 0; x < 8; x++)
            {
                if (p8k1[x] == 48)
                    k1.Append(0);
                //k2.Append(p8k2[x])
                if (p8k1[x] == 49)
                    k1.Append(1);
                //else k1.Append(1);

                if (p8k2[x] == 48)
                    k2.Append(0);
                //k2.Append(p8k2[x])
                if (p8k2[x] == 49)
                    k2.Append(1);
                //else k2.Append(1);
            }
            //copy string to GUI textbox
            txtbx_K1.Text = k1.ToString();
            txtbx_K2.Text = k2.ToString();
        }

        private void btn_toEncrypt_Click(object sender, EventArgs e)
        {
            //txtbx_Result.Text = txtbx_toEncrypt.Text;
            Encrypt();

        }

        private void btn_toDecrypt_Click(object sender, EventArgs e)
        {
            Decrypt();

        }

        //generates  permated array P10
        int[] P10(int[] key)
        {
            //0 1 2 3 4 5 6 7 8 9
            //2 4 1 6 3 9 0 8 7 5

            int[] permutatedArray = new int[10];
            
            permutatedArray[0] = key[2];
            permutatedArray[1] = key[4];
            permutatedArray[2] = key[1];
            permutatedArray[3] = key[6];
            permutatedArray[4] = key[3];
            permutatedArray[5] = key[9];
            permutatedArray[6] = key[0];
            permutatedArray[7] = key[8];
            permutatedArray[8] = key[7];
            permutatedArray[9] = key[5];
 
            return permutatedArray;
        }

        //generates permuted array 8bit
        int[] P8(int[] pt)
        {
            int[] ppa = new int[MAX_8]; //pre-permutatedarray

            for (int i=2,j=0; i<pt.Length;i++,j++)
            {
                ppa[j] = pt[i];
            }

            //0 1 2 3 4 5 6 7
            //1 5 2 0 3 7 4 6
            int[] permutatedArray = new int[8];
  
            permutatedArray[0] = ppa[1];
            permutatedArray[1] = ppa[5];
            permutatedArray[2] = ppa[2];
            permutatedArray[3] = ppa[0];
            permutatedArray[4] = ppa[3];
            permutatedArray[5] = ppa[7];
            permutatedArray[6] = ppa[4];
            permutatedArray[7] = ppa[6];
  
            return permutatedArray;
        }

        //generates permuted array 8bit
        int[] kP8(int[] pt)
        {
            int[] ppa = new int[MAX_8]; //pre-permutatedarray

            for (int i = 2, j = 0; i < pt.Length; i++, j++)
            {
                ppa[j] = pt[i];
            }

            //0 1 2 3 4 5 6 7
            //5 2 6 3 7 4 9 8 --> 3 0 4 1 5 2 7 6
            int[] permutatedArray = new int[8];

            permutatedArray[0] = ppa[3];
            permutatedArray[1] = ppa[0];
            permutatedArray[2] = ppa[4];
            permutatedArray[3] = ppa[1];
            permutatedArray[4] = ppa[5];
            permutatedArray[5] = ppa[2];
            permutatedArray[6] = ppa[7];
            permutatedArray[7] = ppa[6];

            return permutatedArray;
        }

        //left shift 5 bit sequence
        int[] Circular_left_shift(int[] a)
          {
              int[] shifted = new int[MAX_5];

            shifted[0] = a[1];
            shifted[1] = a[2];
            shifted[2] = a[3];
            shifted[3] = a[4];
            shifted[4] = a[0];

            return shifted;
          }

        int[] Circular_two_left_shift(int[] a)
        {
            int[] shifted = new int[MAX_5];

            shifted[0] = a[2];
            shifted[1] = a[3];
            shifted[2] = a[4];
            shifted[3] = a[0];
            shifted[4] = a[1];

            return shifted;
        }

        //generates permuted text IP
        int[] IP8bit(int[] plainText)
          {
              //0 1 2 3 4 5 6 7
              //1 5 2 0 3 7 4 6
              int[] permutatedArray = new int[8];
  
              permutatedArray[0] = plainText[1];
              permutatedArray[1] = plainText[5];
              permutatedArray[2] = plainText[2];
              permutatedArray[3] = plainText[0];
              permutatedArray[4] = plainText[3];
              permutatedArray[5] = plainText[7];
              permutatedArray[6] = plainText[4];
              permutatedArray[7] = plainText[6];
  
              return permutatedArray;
        }

        int[] IP8bitInverse(int[] permutedText)
          {
              //0 1 2 3 4 5 6 7 
              //3 0 2 4 6 1 7 5
              int[] permutatedArray = new int[8];
  
              permutatedArray[0] = permutedText[3];
              permutatedArray[1] = permutedText[0];
              permutatedArray[2] = permutedText[2];
              permutatedArray[3] = permutedText[4];
              permutatedArray[4] = permutedText[6];
              permutatedArray[5] = permutedText[1];
              permutatedArray[6] = permutedText[7];
              permutatedArray[7] = permutedText[5];
  
              return permutatedArray;
          }

        int[] EP4to8bit(int[] fourBit)
        {
            //4bit 0123
            //8bit 30121230
            int[] EParray = new int[8];

            EParray[0] = fourBit[3];
            EParray[1] = fourBit[0];
            EParray[2] = fourBit[1];
            EParray[3] = fourBit[2];
            EParray[4] = fourBit[1];
            EParray[5] = fourBit[2];
            EParray[6] = fourBit[3];
            EParray[7] = fourBit[0];

            return EParray;
        }

        int[] P4(int[] fourBit)
        {
            //4bit 0123
            //p4bit 1320
            int[] P4array = new int[MAX_4];

            P4array[0] = fourBit[3];
            P4array[1] = fourBit[0];
            P4array[2] = fourBit[2];
            P4array[3] = fourBit[1];

            return P4array;
        }

        int[] EPxorK1(int[] EParray)
        {
            int[] XORArray = new int[8];

            //take in key from form
            string K1String = txtbx_K1.Text;
            int[] K1Array = new int[K1String.Length];

            for (int i = 0; i < K1String.Length; i++)
            {
                K1Array[i] = Convert.ToInt16(K1String[i]); //index;
            }

            //XOR EPArray and K1Array
            for (int i = 0; i<8;i++)
            {
                if (K1Array[i] == 48 && EParray[i] == 48)
                    XORArray[i] = 0;
                else if (K1Array[i] == 49 && EParray[i] == 49)
                    XORArray[i] = 0;
                else
                    XORArray[i] = 1;
            }
            return XORArray;
        }

        int[] EPxorK2(int[] EParray)
        {
            int[] XORArray = new int[8];

            //take in key from form
            string K2String = txtbx_K2.Text;
            int[] K2Array = new int[K2String.Length];

            for (int i = 0; i < K2String.Length; i++)
            {
                K2Array[i] = Convert.ToInt16(K2String[i]); //index;
            }

            //XOR EPArray and K1Array
            for (int i = 0; i < 8; i++)
            {
                if (K2Array[i] == 48 && EParray[i] == 48)
                    XORArray[i] = 0;
                else if (K2Array[i] == 49 && EParray[i] == 49)
                    XORArray[i] = 0;
                else
                    XORArray[i] = 1;
            }
            return XORArray;
        }

        int[] P4xorLeft4bit(int[] P4array, int[] Left4bitarray)
        {
            int[] XORArray = new int[MAX_4];

            //XOR P4Array and left4bitArray
            for (int i = 0; i < 4; i++)
            {
                if (P4array[i] == 48 && Left4bitarray[i] == 48)
                    XORArray[i] = 0;
                else if (P4array[i] == 49 && Left4bitarray[i] == 49)
                    XORArray[i] = 0;
                else
                    XORArray[i] = 1;
            }
            return XORArray;
        }

        int[] Sbox(int[] SArray, int boxversion)
        {
            int[] sboxdArray = new int[MAX_2];
            int[] sboxdArray1 = new int[MAX_2];
            int[] sboxdArray2 = new int[MAX_2];
            
            sboxdArray1[0] = SArray[0]; //r
            sboxdArray2[0] = SArray[1]; //c
            sboxdArray2[1] = SArray[2]; //c
            sboxdArray1[1] = SArray[3]; //r

            //int[,] sb0 = { { 01, 00, 11, 10 },
            //               { 11, 10, 01, 00 },
            //               { 00, 10, 01, 11 },
            //               { 11, 01, 11, 10 } };

            //int[,] sb1 = { { 00,01,10,11 }, 
            //               { 10,00,01,11 }, 
            //               { 11,00,01,00 }, 
            //               { 10,01,00,11} };

            if (boxversion == 0)
            {                    //rows                                         //cols
                if (((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 48)) ||
                    ((sboxdArray1[0] == 48 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                    ((sboxdArray1[0] == 48 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 49)))
                {
                    sboxdArray[0] = 0;
                    sboxdArray[1] = 0;
                }

                else if (((sboxdArray1[0] == 48 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 48 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)))
                {
                    sboxdArray[0] = 0;
                    sboxdArray[1] = 1;
                }

                else if (((sboxdArray1[0] == 48 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 48 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 49)))
                {
                    sboxdArray[0] = 1;
                    sboxdArray[1] = 0;
                }

                else if (((sboxdArray1[0] == 48 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 48 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)))
                {
                    sboxdArray[0] = 1;
                    sboxdArray[1] = 1;
                }
            }

            if (boxversion == 1)
            {
                if (((sboxdArray1[0] == 48 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 48)) ||
                    ((sboxdArray1[0] == 48 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                    ((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                    ((sboxdArray1[0] == 49 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)) ||
                    ((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)) )
                {
                    sboxdArray[0] = 0;
                    sboxdArray[1] = 0;
                }

                else if (((sboxdArray1[0] == 48 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)))
                {
                    sboxdArray[0] = 0;
                    sboxdArray[1] = 1;
                }

                else if (((sboxdArray1[0] == 48 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 48 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 48)))
                {
                    sboxdArray[0] = 1;
                    sboxdArray[1] = 0;
                }

                else if (((sboxdArray1[0] == 49 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 48 && sboxdArray2[1] == 48)) ||
                         ((sboxdArray1[0] == 48 && sboxdArray1[1] == 48) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 48 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 49)) ||
                         ((sboxdArray1[0] == 49 && sboxdArray1[1] == 49) && (sboxdArray2[0] == 49 && sboxdArray2[1] == 49)))
                {
                    sboxdArray[0] = 1;
                    sboxdArray[1] = 1;
                }
            }

            return sboxdArray;
        }

        void Encrypt()
        {
            int[] p8Array = new int[MAX_8], //for Permutation 8 array
                p8Left4bit = new int[MAX_4], p8Right4bit = new int[MAX_4], //To split 8bit into 4bit
                EParray = new int[MAX_8], XORarray = new int[MAX_8], //for 2 leftshift part 1/2
                SO04bit = new int[MAX_4], SO14bit = new int[MAX_4], //for post shift array
                p8k1 = new int[MAX_8], p8k2 = new int[MAX_8],   //for key1 and key 2
                p2left = new int[MAX_2], p2right = new int[MAX_2], //for 2bit sbox
                p4array = new int[MAX_4], //for 4bit perm
                switch8bit = new int[MAX_8]; //for unaltered 4bitRight and postP4xor switch 

            int sboxnumb = 0, sboxnumb1 = 1;

            //take in key from form
            string enString = txtbx_toEncrypt.Text;

            int[] enArray = new int[enString.Length];

            for (int i = 0; i < enString.Length; i++)
            {
                enArray[i] = Convert.ToInt16(enString[i]); //index;
            }

            //generate Perm8 Array
            p8Array = IP8bit(enArray);

            //copy 1st 4 bits into 1st array, copy 2nd 4 bits into 2nd array
            for (int i = 0; i < 4; i++)
            {
                p8Left4bit[i] = p8Array[i];
            }
            for (int i = 0, j = 4; j < 8; i++, j++)
            {
                p8Right4bit[i] = p8Array[j];
            }

            //send right 4bit into "entend and permutate" EP function
            EParray = EP4to8bit(p8Right4bit);

            //Send EParray to XOR function with K1 key
            XORarray = EPxorK1(EParray);

            //split XOR array into 2 4bit arrays
            for (int i = 0; i < 4; i++)
            {
                SO04bit[i] = XORarray[i];
            }
            for (int i = 0, j = 4; j < 8; i++, j++)
            {
                SO14bit[i] = XORarray[j];
            }

            //array through sbox from 4bit to 2bit
            p2left = Sbox(SO04bit, sboxnumb);
            p2right = Sbox(SO14bit, sboxnumb1);

            //combine 2bit to 4bit
            for (int i = 0; i < p2left.Length; i++)
            {
                p4array[i] = p2left[i];
            }

            for (int i = 0, j = 2; i < p2right.Length; i++, j++)
            {
                p4array[j] = p2right[i];
            }

            //4bit permutation
            p4array = P4(p4array);

            //4bit xor with 4bit-left-from-8bit
            p4array = P4xorLeft4bit(p4array, p8Left4bit);

            //rebuild 8bit with switch of p84bit and p4array
            for (int i = 0; i < p8Right4bit.Length; i++)
            {
                switch8bit[i] = p8Right4bit[i];
            }

            for (int i = 0, j = 4; i < p4array.Length; i++, j++)
            { 
                switch8bit[j] = p4array[i];
            }


            ///////////////////////phase2///////////////////////

            //generate Perm8 Array
            p8Array = IP8bit(switch8bit);

            //copy 1st 4 bits into 1st array, copy 2nd 4 bits into 2nd array
            for (int i = 0; i < 4; i++)
            {
                p8Left4bit[i] = p8Array[i];
            }
            for (int i = 0, j = 4; j < 8; i++, j++)
            {
                p8Right4bit[i] = p8Array[j];
            }

            //send right 4bit into "entend and permutate" EP function
            EParray = EP4to8bit(p8Right4bit);

            //Send EParray to XOR function with K1 key
            XORarray = EPxorK2(EParray);

            //split XOR array into 2 4bit arrays
            for (int i = 0; i < 4; i++)
            {
                SO04bit[i] = XORarray[i];
            }
            for (int i = 0, j = 4; j < 8; i++, j++)
            {
                SO14bit[i] = XORarray[j];
            }


            //array through sbox from 4bit to 2bit
            p2left = Sbox(SO04bit, sboxnumb );
            p2right = Sbox(SO14bit, sboxnumb1);

            //combine 2bit to 4bit
            for (int i = 0; i < p2left.Length; i++)
                p4array[i] = p2left[i];

            for (int i = 0, j = 2; i < p2right.Length; i++, j++)
                p4array[j] = p2right[i];

            //4bit permutation
            p4array = P4(p4array);

            //4bit xor with 4bit-left-from-8bit
            p4array = P4xorLeft4bit(p4array, p8Left4bit);

            //rebuild 8bit with p84bit and p4array
            for (int i = 0; i < p4array.Length; i++)
                switch8bit[i] = p4array[i];
            for (int i = 0,j=4; i < p8Right4bit.Length; i++,j++)
                switch8bit[j] = p8Right4bit[i];

            switch8bit = IP8bitInverse(switch8bit);

            StringBuilder encrypt = new StringBuilder();

            //copy array to string
            for (int x = 0; x < 8; x++)
            {
                if (switch8bit[x] == 48 || switch8bit[x] == 0)
                    encrypt.Append(0);
                if(switch8bit[x] == 49 || switch8bit[x] == 1)
                    encrypt.Append(1);
            }

            //copy string to GUI textbox
            txtbx_Result.Text = encrypt.ToString();
        }

        void Decrypt()
        {
            int[] p8Array = new int[MAX_8], //for Permutation 8 array
                p8Left4bit = new int[MAX_4], p8Right4bit = new int[MAX_4], //To split 8bit into 4bit
                EParray = new int[MAX_8], XORarray = new int[MAX_8], //for 2 leftshift part 1/2
                SO04bit = new int[MAX_4], SO14bit = new int[MAX_4], //for post shift array
                p8k1 = new int[MAX_8], p8k2 = new int[MAX_8],   //for key1 and key 2
                p2left = new int[MAX_2], p2right = new int[MAX_2], //for 2bit sbox
                p4array = new int[MAX_4], //for 4bit perm
                switch8bit = new int[MAX_8]; //for unaltered 4bitRight and postP4xor switch 

            int sboxnumb = 0, sboxnumb2 = 1;

            //take in key from form
            string enString = txtbx_toDecrypt.Text;

            int[] enArray = new int[enString.Length];

            for (int i = 0; i < enString.Length; i++)
            {
                enArray[i] = Convert.ToInt16(enString[i]); //index;
            }

            //generate Perm8 Array
            p8Array = IP8bit(enArray);

            //copy 1st 4 bits into 1st array, copy 2nd 4 bits into 2nd array
            for (int i = 0; i < 4; i++)
            {
                p8Left4bit[i] = p8Array[i];
            }
            for (int i = 0, j = 4; j < 8; i++, j++)
            {
                p8Right4bit[i] = p8Array[j];
            }

            //send right 4bit into "entend and permutate" EP function
            EParray = EP4to8bit(p8Right4bit);

            //Send EParray to XOR function with K1 key
            XORarray = EPxorK2(EParray);

            //split XOR array into 2 4bit arrays
            for (int i = 0; i < 4; i++)
            {
                SO04bit[i] = XORarray[i];
            }
            for (int i = 0, j = 4; j < 8; i++, j++)
            {
                SO14bit[i] = XORarray[j];
            }

            //array through sbox from 4bit to 2bit
            p2left = Sbox(SO04bit, sboxnumb);
            p2right = Sbox(SO14bit,sboxnumb2);

            //combine 2bit to 4bit
            for (int i = 0; i < p2left.Length; i++)
                p4array[i] = p2left[i];

            for (int i = 0, j = 2; i < p2right.Length; i++, j++)
                p4array[j] = p2right[i];

            //4bit permutation
            p4array = P4(p4array);

            //4bit xor with 4bit-left-from-8bit
            p4array = P4xorLeft4bit(p4array, p8Left4bit);

            //rebuild 8bit with switch of p84bit and p4array
            for (int i = 0; i < p8Right4bit.Length; i++)
                switch8bit[i] = p8Right4bit[i];

            for (int i = 0, j = 4; i < p4array.Length; i++, j++)
                switch8bit[j] = p4array[i];

            ///////////////////////phase2///////////////////////

            //generate Perm8 Array
            p8Array = IP8bit(switch8bit);

            //copy 1st 4 bits into 1st array, copy 2nd 4 bits into 2nd array
            for (int i = 0; i < 4; i++)
            {
                p8Left4bit[i] = p8Array[i];
            }
            for (int i = 0, j = 4; j < 8; i++, j++)
            {
                p8Right4bit[i] = p8Array[j];
            }

            //send right 4bit into "entend and permutate" EP function
            EParray = EP4to8bit(p8Right4bit);

            //Send EParray to XOR function with K1 key
            XORarray = EPxorK1(EParray);

            //split XOR array into 2 4bit arrays
            for (int i = 0; i < 4; i++)
            {
                SO04bit[i] = XORarray[i];
            }
            for (int i = 0, j = 4; j < 8; i++, j++)
            {
                SO14bit[i] = XORarray[j];
            }

            //array through sbox from 4bit to 2bit
            p2left = Sbox(SO04bit, sboxnumb);
            p2right = Sbox(SO14bit, sboxnumb2);

            //combine 2bit to 4bit
            for (int i = 0; i < p2left.Length; i++)
                p4array[i] = p2left[i];

            for (int i = 0, j = 2; i < p2right.Length; i++, j++)
                p4array[j] = p2right[i];

            //4bit permutation
            p4array = P4(p4array);

            //4bit xor with 4bit-left-from-8bit
            p4array = P4xorLeft4bit(p4array, p8Left4bit);

            //rebuild 8bit with p84bit and p4array
            for (int i = 0; i < p4array.Length; i++)
                switch8bit[i] = p4array[i];
            for (int i = 0, j = 4; i < p8Right4bit.Length; i++, j++)
                switch8bit[j] = p8Right4bit[i];

            switch8bit = IP8bitInverse(switch8bit);

            StringBuilder decrypt = new StringBuilder();

            //copy array to string
            for (int x = 0; x < 8; x++)
            {
                if (switch8bit[x] == 48)
                    decrypt.Append(0);
                else
                    decrypt.Append(1);
            }

            //copy string to GUI textbox
            txtbx_Result.Text = decrypt.ToString();
        }

    }

}
