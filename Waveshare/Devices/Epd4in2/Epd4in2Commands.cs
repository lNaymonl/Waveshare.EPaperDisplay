namespace Waveshare.Devices.Epd4in2 {
    internal enum Epd4in2Commands {
        /// <summary>
        /// Default value
        /// </summary>
        None = -1,
        /// <summary>
        /// Panel Setting (PSR)
        /// </summary>
        PanelSetting = 0x00,
        /// <summary>
        /// Power Setting (PWR)
        /// </summary>
        PowerSetting = 0x01,
        /// <summary>
        /// Power OFF (POF)
        /// </summary>
        PowerOff = 0x02,
        /// <summary>
        /// Power OFF Sequence Setting(PFS)
        /// </summary>
        PowerOffSequenceSetting = 0x03,
        /// <summary>
        /// Power ON (PON)
        /// </summary>
        PowerOn = 0x04,
        /// <summary>
        /// Power ON Measure (PMES)
        /// </summary>
        PowerOnMeasure = 0x05,
        /// <summary>
        /// Booster Soft Start (BTST)
        /// </summary>
        BoosterSoftStart = 0x06,
        /// <summary>
        /// Deep Sleep
        /// </summary>
        DeepSleep = 0x07,
        /// <summary>
        /// Display Start Transmission 1 (DTM1, white/black Data) (x-byte command)
        /// </summary>
        DataStartTransmission1 = 0x10,
        /// <summary>
        /// Data Stop
        /// </summary>
        DataStop = 0x11,
        /// <summary>
        /// Display Refresh (DRF)
        /// </summary>
        DisplayRefresh = 0x12,
        /// <summary>
        /// VCOM LUT(LUTC) (45-byte command, structure of bytes 2~7 repeated)
        /// </summary>
        VcomLut = 0x20,
        /// <summary>
        /// W2W LUT (LUTWW) (43-byte command, structure of bytes 2~7 repeated 7 times)
        /// </summary>
        W2WLut = 0x21,
        /// <summary>
        /// B2W LUT (LUTBW / LUTR) (43-byte command, structure of bytes 2~7 repeated 7 times)
        /// </summary>
        B2WLut = 0x22,
        /// <summary>
        /// W2B LUT (LUTWB / LUTW) (43-byte command, structure of bytes 2~7 repeated 7 times)
        /// </summary>
        W2BLut = 0x23,
        /// <summary>
        /// B2B LUT (LUTBB / LUTB) (43-byte command, sturcture of bytes 2~7 repeated 7 times)
        /// </summary>
        B2BLut = 0x24,
        /// <summary>
        /// PLL control(PLL)
        /// </summary>
        PllControl = 0x30,
        /// <summary>
        /// Temperature Sensor Calibration (TSC)
        /// </summary>
        TemperatureSensorCalibration = 0x40,
        /// <summary>
        /// Temperature Sensor Selection (TSE)
        /// </summary>
        TemperatureSensorSelection = 0x41,
        /// <summary>
        /// Temperature Sensor Write (TSW)
        /// </summary>
        TemperatureSensorWrite = 0x42,
        /// <summary>
        /// Temperature Sensor Read (TSR)
        /// </summary>
        TemperatureSensorRead = 0x43,
        /// <summary>
        /// Vcom and data interval setting (CDI)
        /// </summary>
        VcomAndDataInterval = 0x50,
        /// <summary>
        /// Lower Power Detection (LPD)
        /// </summary>
        LowerPowerDetection = 0x51,
        /// <summary>
        /// TCON setting (TCON)
        /// </summary>
        Tcon = 0x60,
        /// <summary>
        /// Resolution setting (TRES)
        /// </summary>
        Resolution = 0x61,
        /// <summary>
        /// GSST Setting (GSST)
        /// </summary>
        Gsst = 0x65,
        /// <summary>
        /// Get Status (FLG)
        /// </summary>
        GetStatus = 0x71,
        /// <summary>
        /// Auto Measurement Vcom
        /// </summary>
        AutoMeasurementVcom = 0x80,
        /// <summary>
        /// Read Vcom Value (VV)
        /// </summary>
        ReadVcomValue = 0x81,
        /// <summary>
        /// VCM_DC Setting (VDCS)
        /// </summary>
        VCM_DC = 0x82,
        /// <summary>
        /// Partial Window (PTL)
        /// </summary>
        PartialWindow = 0x90,
        /// <summary>
        /// Partial In (PTIN)
        /// </summary>
        PartialIn = 0x91,
        /// <summary>
        /// Partial Out (PTOUT)
        /// </summary>
        PartialOut = 0x92,
        /// <summary>
        /// Program Mode (PGM)
        /// </summary>
        ProgramMode = 0xA0,
        /// <summary>
        /// Active Programming (APG)
        /// </summary>
        ActiveProgramming = 0xA1,
        /// <summary>
        /// Read OTP (ROTP)
        /// </summary>
        ReadOTP = 0xA2,
        /// <summary>
        /// Power Saving (PWS
        /// </summary>
        PowerSaving = 0xE3
    }
}