internal interface IBitGetable
{
    bool GetBitByIndex(byte index);
    void SetBitByIndex(byte index, bool value);
}


// internal class Bits : IBitGetable  
// {
//     public byte Value { get; set; }
    
//     public bool this[int index]
//     {
//         get
//         {
//             if (index > 7 || index < 0)
//                 return false;
//             return ((Value >> index) & 1) == 1;
//         }
//         set
//         {
//             if (index > 7 || index < 0) return;
//             if (value == true)
//                 Value = (byte)(Value | (1 << index));
//             else
//             {
//                 var mask = (byte)(1 << index);
//                 mask = (byte)(0xf ^ mask);
//                 Value = (byte)(Value & mask);
//             }

//         }
//     }

//     public Bits(byte b)
//     {
//         this.Value = b;
//     }

//     public Bits(int b)
//     {
//         this.Value = (byte)b;
//     }

//     public Bits(long b)
//     {
//         this.Value = (byte)b;
//     }

//     public static implicit operator byte(Bits b) => b.Value;
//     public static explicit operator Bits(byte b) => new(b);

//     public static implicit operator int(Bits b) => b.Value;
//     public static explicit operator Bits(int b) => new(b);

//     public static implicit operator long(Bits b) => b.Value;
//     public static explicit operator Bits(long b) => new(b);

// }