using System.Threading;
using Waveshare.Common;

namespace Waveshare.Devices.Epd4in2 {
    internal sealed class Epd4in2 : EPaperDisplayBase {
        public override int Width { get; } = 400;
        public override int Height { get; } = 300;
        public override int PixelPerByte { get; } = 8;
        public override ByteColor[] SupportedByteColors { get; } = { ByteColors.White, ByteColors.Gray, ByteColors.Black };
        public override byte[] DeviceByteColors { get; } = { Epd4in2Colors.White, Epd4in2Colors.Gray, Epd4in2Colors.Black };
        protected override byte GetStatusCommand { get; } = (byte)Epd4in2Commands.GetStatus;
        protected override byte StartDataTransmissionCommand { get; } = (byte)Epd4in2Commands.DataStartTransmission1;
        protected override byte StopDataTransmissionCommand { get; } = (byte)Epd4in2Commands.DataStop;
        protected override byte DeepSleepComand { get; } = (byte)Epd4in2Commands.DeepSleep;

        private static readonly byte[] lut_vcom0 = {
            0x00, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x00, 0x0F, 0x0F, 0x00, 0x00, 0x01,
            0x00, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00,
        };

        private static readonly byte[] lut_ww = {
            0x50, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x90, 0x0F, 0x0F, 0x00, 0x00, 0x01,
            0xA0, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        };
        private static readonly byte[] lut_bw = {
            0x50, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x90, 0x0F, 0x0F, 0x00, 0x00, 0x01,
            0xA0, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        };
        private static readonly byte[] lut_wb = {
            0xA0, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x90, 0x0F, 0x0F, 0x00, 0x00, 0x01,
            0x50, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        };
        private static readonly byte[] lut_bb = {
            0x20, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x90, 0x0F, 0x0F, 0x00, 0x00, 0x01,
            0x10, 0x08, 0x08, 0x00, 0x00, 0x02,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        };

        #region Public Methods
        public override void Clear()
        {
            FillColor(Epd4in2Commands.DataStartTransmission1, ByteColors.White);
            FillColor(Epd4in2Commands.DataStartTransmission1, ByteColors.White);
            TurnOnDisplay();
        }

        public override void ClearBlack()
        {
            FillColor(Epd4in2Commands.DataStartTransmission1, ByteColors.Black);
            TurnOnDisplay();
        }

        public override void PowerOn()
        {
            SendCommand(Epd4in2Commands.PowerOn);
            DeviceWaitUntilReady();
        }

        public override void PowerOff()
        {
            SendCommand(Epd4in2Commands.PowerOff);
            DeviceWaitUntilReady();
        }

        public void DeviceWaitUntilReady() {
            WaitUntilReady();
            Thread.Sleep(200);
        }
        #endregion Public Methods

        #region Protected Methods
        protected override void DeviceInitialize()
        {
            Reset();

            SendCommand(Epd4in2Commands.BoosterSoftStart);
            SendData(0x17);
            SendData(0x17);
            SendData(0x17);

            SendCommand(Epd4in2Commands.PowerSetting);
            SendData(0x03);
            SendData(0x00);
            SendData(0x2b);
            SendData(0x2b);

            SendCommand(Epd4in2Commands.PowerOn);
            DeviceWaitUntilReady();

            SendCommand(Epd4in2Commands.PanelSetting);
            SendData(0xbf);

            SendCommand(Epd4in2Commands.PllControl);
            SendData(0x3c);

            SendCommand(Epd4in2Commands.Resolution);
            SendData(0x01);
            SendData(0x90);
            SendData(0x01);
            SendData(0x2c);

            SendCommand(Epd4in2Commands.VCM_DC);
            SendData(0x12);

            SendCommand(Epd4in2Commands.VcomAndDataInterval);
            SendData(0x97);

            SetLut();
        }

        protected override void TurnOnDisplay()
        {
            SendCommand(Epd4in2Commands.DisplayRefresh);
            Thread.Sleep(100);
            DeviceWaitUntilReady();
        }

        protected override byte ColorToByte(ByteColor rgb) {
            if (Epd4in2Colors.Gray - Epd4in2Colors.Gray / 3 < rgb.R) return Epd4in2Colors.White;
            if (Epd4in2Colors.Gray + Epd4in2Colors.Gray / 3 < rgb.R) return Epd4in2Colors.Gray;
            return Epd4in2Colors.Black;
        }
        #endregion Protected Methods

        #region Private Methods
        private void SetLut() {
            SendCommand(Epd4in2Commands.VcomLut);
            SendData(lut_vcom0);

            SendCommand(Epd4in2Commands.W2WLut);
            SendData(lut_ww);

            SendCommand(Epd4in2Commands.B2WLut);
            SendData(lut_bw);

            SendCommand(Epd4in2Commands.W2BLut);
            SendData(lut_bb);

            SendCommand(Epd4in2Commands.B2BLut);
            SendData(lut_wb);
        }

        private void SendCommand(Epd4in2Commands command) {
            SendCommand((byte)command);
        }

        private void FillColor(Epd4in2Commands command, ByteColor rgb) {
            var outputLine = GetColoredLineOnDevice(rgb);

            SendCommand(command);

            for (var y = 0; y < Height; ++y) {
                SendData(outputLine);
            }
        }
        #endregion Private Methods
    }
}