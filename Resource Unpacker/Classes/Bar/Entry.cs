﻿using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Archive_Unpacker.Classes.Bar
{
    public class Entry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public long fileOffset { get; set; }
        public uint fileLength1 { get; set; }
        public uint fileLength2 { get; set; }
        public ushort year { get; set; }
        public ushort month { get; set; }
        public ushort dayOfWeek { get; set; }
        public ushort day { get; set; }
        public ushort hour { get; set; }
        public ushort minute { get; set; }
        public ushort second { get; set; }
        public ushort msecond { get; set; }
        public int fileNameLength { get; set; }
        public string fileName { get; set; }
        public bool isCompressed { get; set; }

        public DateTime lastModifiedDate
        {
            get
            {
                return new DateTime(year, month, day, hour, minute, second, msecond, DateTimeKind.Utc);
            }
        }

        public string fileFormat
        {
            get
            {
                return (isCompressed ? "Compressed ":"") + Path.GetExtension(fileName).ToUpper();
            }
        }

        //public MemoryStream streamCache { get; set; }

        /*          public Stream Ensure(Stream inStream)
                  {
                      if (streamCache != null)
                      {
                          streamCache.Position = 0;
                          return streamCache;
                      }
                      lock (inStream)
                      {
                          var data = new byte[fileLength2];
                          inStream.Seek(fileOffset, SeekOrigin.Begin);
                          inStream.Read(data, 0, data.Length);
                          NotifyPropertyChanged("streamCache");
                          return streamCache = new MemoryStream(data);
                      }
                  }
                  public void SetData(byte[] newData)
                  {
                      streamCache = new MemoryStream(newData);
                     // Size = Size2 = newData.Length;
                  }*/


    }
}
