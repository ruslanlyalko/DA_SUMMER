﻿using CQG;
using DADataManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace DADataManager.SqlQueryBuilders
{

    class DAQueryBuilder
    {

        #region CONSTANTS

        private const string TblUsers = "tbl_users";
        private const string TblSymbols = "tbl_symbols";
        private const string TblGroups = "tbl_groups";
        private const string TblSymbolsInGroups = "tbl_symbols_in_groups";
        private const string TblGroupsForUsers = "tbl_groups_for_users";
        private const string TblSymbolsForUsers = "tbl_symbols_for_users";

        private const string TblMissingBarException = "tblMissingBarException";
        private const string TblSessionHolidayTimes = "tblSessionHolidayTimes";
        private const string Tblfullreport = "tblfullreport";

        private const string TblNotChangedValues = "tbl_not_changed_values";
        private const string TblSessions = "tbl_sessions";
        private const string TblSessionsForGroups = "tbl_sesions_for_groups";
        private const string TblLogs = "tbl_logs";
        private const string TblDailyValue = "tbl_daily_values";
        private const string TblSymbolsFormat = "tbl_symbols_format";
        private const string TblUserInfo = "tbl_user_info";

        #endregion

     
        public static string GetCreateTablesSql()
        {
        //todo create tables when user connect to local DB

            string createUserInfoTable = "CREATE TABLE IF NOT EXISTS `" + TblUserInfo + "`("
                               + "`Id` int(12) unsigned not null auto_increment,"
                               +"`UserID` int(12) not null,"
                               +"`AutoCollect` bool not null,"
                               +"`EmeilFinish` bool not null,"
                               +"`BarStart` int(12) not null,"
                               +"`BarEnd` int(12) not null,"
                               + "PRIMARY KEY (`Id`),"
                               + "UNIQUE INDEX `UNQ_DATA_INDEX` (`UserID`)"
                               +")"
                               + "COLLATE='latin1_swedish_ci'"
                               + "ENGINE=InnoDB;";  
        
         string createNotChangedValuesTable = "CREATE TABLE  IF NOT EXISTS `" + TblNotChangedValues + "`("
                               + "`Id` int(12) unsigned not null auto_increment,"
                               + "`Symbol` varchar(50) not null,"
                               + "`TickSize` double not null,"
                               + "`Currency` varchar(50) not null,"
                // + "`Expiration` DateTime null DEFAULT '" + s + "', "
                               + "`TickValue` double not null,"
                               + "PRIMARY KEY (`Id`),"
                               + "UNIQUE INDEX `UNQ_DATA_INDEX` (`Symbol`)"
                               + ")"
                               + "COLLATE='latin1_swedish_ci'"
                               + "ENGINE=InnoDB;";  

        string createDailyTable = "CREATE TABLE  IF NOT EXISTS `"+TblDailyValue+"`("
                                             +"`Id` int(12) unsigned not null auto_increment,"
                                             +"`Symbol` varchar(50) not null,"
                                             + "`IndicativeOpen` double not null," 
                                             + "`Settlement` double not null,"
                                             + "`Marker` double not null,"
                                             + "`TodayMarker` double not null,"
                                             + "`Date` DateTime not null,"
                                             + "`Expiration` DateTime not null,"
                                             + "PRIMARY KEY (`Id`)"
                                             + ")"
                                             + "COLLATE='latin1_swedish_ci'"
                                             + "ENGINE=InnoDB;";
         ///   
            string createUsersSql = "CREATE TABLE  IF NOT EXISTS `" + TblUsers + "` ("
                                     + "`ID` INT(12) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                     + "`UserName` VARCHAR(50) NOT NULL,"
                                     + "`UserPassword` VARCHAR(50) NOT NULL,"
                                     + "`UserFullName` VARCHAR(100) NULL,"
                                     + "`UserEmail` VARCHAR(50) NULL,"
                                     + "`UserPhone` VARCHAR(50) NULL,"
                                     + "`UserIpAddress` VARCHAR(50) NULL,"
                                     + "`UserBlocked` BOOLEAN NULL,"
                                     + "`UserAllowDataNet` BOOLEAN NULL,"
                                     + "`UserAllowTickNet` BOOLEAN NULL,"
                                     + "`UserAllowLocal` BOOLEAN NULL,"
                                     + "`UserAllowRemote` BOOLEAN NULL,"
                                     + "`UserAllowAnyIP` BOOLEAN NULL,"
                                     + "`UserAllowMissBars` BOOLEAN NULL,"
                                     + "`UserAllowCollectFrCQG` BOOLEAN NULL,"
                                     + "`UserAllowDexport` BOOLEAN NULL,"
                                     + "PRIMARY KEY (`ID`,`UserName`)"
                                     + ")"
                                     + "COLLATE='latin1_swedish_ci'"
                                     + "ENGINE=InnoDB;";            

            const string createSymbolsSql = "CREATE TABLE  IF NOT EXISTS `" + TblSymbols + "` ("
                                     + "`ID` INT(10) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                     + "`SymbolName` VARCHAR(50) NULL,"
                                     + "PRIMARY KEY (`ID`,`SymbolName`)"
                                     + ")"
                                     + "COLLATE='latin1_swedish_ci'"
                                     + "ENGINE=InnoDB;";
            

            const string createSymbolsGroups = "CREATE TABLE  IF NOT EXISTS `" + TblGroups + "` ("
                                             + "`ID` INT(10) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                             + "`GroupName` VARCHAR(100) NULL,"
                                             + "`TimeFrame` VARCHAR(30) NULL,"
                                             + "`Start` DateTime NULL, "
                                             + "`End` DateTime NULL, "
                                             + "`CntType` VARCHAR(40) NULL,"
                                             + "PRIMARY KEY (`ID`,`GroupName`)"
                                             + ")"
                                             + "COLLATE='latin1_swedish_ci'"
                                             + "ENGINE=InnoDB;";
            
            const string createSymbolsInGroups = "CREATE TABLE  IF NOT EXISTS `" + TblSymbolsInGroups + "` ("
                                             + "`ID` INT(10) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                             + "`GroupID` INT(10) NULL,"
                                             + "`SymbolID` INT(10) NULL,"
                                             + "`SymbolName` VARCHAR(50) NOT NULL,"
                                             + "PRIMARY KEY (`ID`, `GroupID`, `SymbolID`)"
                                             + ")"
                                             + "COLLATE='latin1_swedish_ci'"
                                             + "ENGINE=InnoDB;";
            

            const string createGroupsForUsers = "CREATE TABLE  IF NOT EXISTS `" + TblGroupsForUsers + "` ("
                                             + "`ID` INT(10) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                             + "`UserID` INT(10) NULL,"
                                             + "`GroupID` INT(10) NULL,"
                                             + "`GroupName` VARCHAR(100) NOT NULL,"
                                             + "`TimeFrame` VARCHAR(30) NULL,"
                                             + "`Start` DateTime NULL, "
                                             + "`End` DateTime NULL, "
                                             + "`CntType` VARCHAR(40) NULL,"
                                             + "`Privilege` VARCHAR(40) NULL,"
                                             + "`AppType` VARCHAR(40) NULL,"

                                             + "`IsAutoModeEnabled` BOOLEAN NULL, "
                                             + "`Depth` INT(10) NULL,"

                                             + "PRIMARY KEY (`ID`)"
                                             + ")"
                                             + "COLLATE='latin1_swedish_ci'"
                                             + "ENGINE=InnoDB;";
            


            const string createSymbolsForUsers = "CREATE TABLE  IF NOT EXISTS `" + TblSymbolsForUsers + "` ("
                                             + "`ID` INT(10) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                             + "`UserID` INT(10) NULL,"
                                             + "`SymbolID` INT(10) NULL,"
                                             + "`TNorDN` BOOLEAN NULL,"
                                             + "PRIMARY KEY (`ID`)"
                                             + ")"
                                             + "COLLATE='latin1_swedish_ci'"
                                             + "ENGINE=InnoDB;";

            const string createSessions = "CREATE TABLE  IF NOT EXISTS `" + TblSessions + "` ("
                                 + "`ID` INT(10) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                 + "`Name` VARCHAR(100) NOT NULL,"
                                 + "`StartTime` DateTime NULL, "
                                 + "`EndTime` DateTime NULL, "
                                 + "`IsStartYesterday` BOOLEAN NULL,"
                                 + "`Days` VARCHAR(30) NULL,"
                                 + "PRIMARY KEY (`ID`)"
                                 + ")"
                                 + "COLLATE='latin1_swedish_ci'"
                                 + "ENGINE=InnoDB;";


            const string createSessionsForGroups = "CREATE TABLE  IF NOT EXISTS `" + TblSessionsForGroups+ "` ("
                                             + "`ID` INT(10) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                             + "`GroupId` INT(10) NULL,"
                                             + "`SessionId` INT(10) NULL,"                                             
                                             + "PRIMARY KEY (`ID`)"
                                             + ")"
                                             + "COLLATE='latin1_swedish_ci'"
                                             + "ENGINE=InnoDB;";
            const string createLogsSql = "CREATE TABLE  IF NOT EXISTS `" + TblLogs + "` ("
                                     + "`ID` INT(10) UNSIGNED  NOT NULL AUTO_INCREMENT,"
                                     + "`UserID` INT(10) NULL,"
                                     + "`Date` DateTime NULL, "
                                     + "`MsgType` INT(10) NULL,"
                                     + "`Symbol` VARCHAR(50) NULL,"
                                     + "`Group` VARCHAR(50) NULL,"
                                     + "`Status` INT(10) NULL,"
                                     + "`Timeframe` VARCHAR(50) NULL,"
                                     + "`Application` VARCHAR(50) NULL,"
                                     + "`Comments` VARCHAR(200) NULL,"
                                     + "PRIMARY KEY (`ID`)"
                                     + ")"
                                     + "COLLATE='latin1_swedish_ci'"
                                     + "ENGINE=InnoDB;";
            

            const string createSymbolsFormatTable = "CREATE TABLE  IF NOT EXISTS `" + TblSymbolsFormat+ "`("
                                                 + "`Id` int(12) unsigned not null auto_increment,"
                                                 + "`Symbol` varchar(50) not null  DEFAULT '',"
                                                 + "`Format`  varchar(50) not null  DEFAULT '9,6',"
                                                 + "PRIMARY KEY (`Id`),"
                                                 + "UNIQUE INDEX `UNQ_DATA_INDEX` (`Symbol`)"                                                 
                                                 + ")"
                                                 + "COLLATE='latin1_swedish_ci'"
                                                 + "ENGINE=InnoDB;";

            var alterLogs ="ALTER TABLE `tbl_logs`	ADD COLUMN `Comments` VARCHAR(200) NULL DEFAULT '' AFTER `Application`;";

            



            return createGroupsForUsers + createSymbolsForUsers + createSymbolsGroups +
                createSymbolsInGroups + createSymbolsSql + createUsersSql + createSessions+createSessionsForGroups
                + createDailyTable + createLogsSql + createSymbolsFormatTable + createSymbolsGroups + createNotChangedValuesTable + createUserInfoTable + alterLogs;
        }

        public static string GetAddGroupSql(GroupModel group)
        {
            string startDateStr = Convert.ToDateTime(group.Start).ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            string endDateStr = Convert.ToDateTime(group.End).ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);

            var query = "INSERT IGNORE INTO " + TblGroups;
            query += "(GroupName, TimeFrame, Start, End, CntType) VALUES";
            query += "('" + group.GroupName + "',";
            query += " '" + group.TimeFrame + "',";
            query += " '" + startDateStr + "',";
            query += " '" + endDateStr + "',";
            query += " '" + group.CntType + "');COMMIT;";
            
            return query;
        }

        internal static string GetSessionsInGroupSql(int groupId)
        {
            string sql = "SELECT * FROM " + TblSessionsForGroups
                        + " LEFT JOIN " + TblSessions
                        + " ON " + TblSessionsForGroups + ".SessionId = "
                        + TblSessions + ".Id" + " WHERE " + TblSessionsForGroups + ".GroupId= " + groupId + ";";
            return sql;
        }

        internal static string GetRemoveSessionSql(int groupId, int sessionId)
        {
            string sql = " DELETE FROM "+TblSessionsForGroups+" WHERE Id="+sessionId+" AND GroupId="+groupId+"; COMMIT;";
            return sql;
        }

        internal static string GetGroups(int userId, ApplicationType applicationType, bool sortingMode)
        {
            return "SELECT * FROM " + TblGroupsForUsers + " WHERE UserID=" + userId + " AND AppType = '" + applicationType.ToString() + "' ORDER BY GroupName "+(sortingMode?"ASC":"DESC");
        }




        internal static string GetSessionsSql()
        {
            string sql = "SELECT * FROM " + TblSessions;
            return sql;
        }

        internal static string RemoveSessionSql(int sessionId)
        {
            string sql = "DELETE FROM " + TblSessions + " WHERE Id = " + sessionId;
            return sql;
        }

        public static String InsertData_dom(String tableName, CQGInstrument instrument, int depth, uint groupID, bool isNew, string userName, out double askPrice, out int askVol, out double bidPrice, out int bidVol, DateTime serverTime)
        {
            var newTable = "DM_" + tableName.Substring(3, tableName.Length - 3).ToUpper();

            String symbol = instrument.FullName;
            String query = "INSERT IGNORE INTO `" + newTable + "`";
            query += "(`Symbol`,`Depth`,`DOMBid`,`DOMAsk`,`DOMBidVol`,`DOMAskVol`,`Trade`,`TradeVol`,`Time`, `TimeLocal`,GroupID, UserName)";
            String runQuery = "";
            int balancedDepth = (instrument.DOMAsks.Count < instrument.DOMBids.Count)
                                    ? instrument.DOMAsks.Count
                                    : instrument.DOMBids.Count;
            askPrice = 0;
            askVol = 0;
            bidPrice = 0;
            bidVol = 0;
            for (int index = 0; ((index < balancedDepth) && (index < depth)); index++)
            {
                //query += "(`symbol`,`depth`,`DOMBid`,`DOMAsk`,`DOMBidVol`,`DOMAskVol`,`Trade`,`TradeVol`,`ts`)";
                CQGQuote domAsk = instrument.DOMAsks[index];
                CQGQuote domBid = instrument.DOMBids[index];

                runQuery += query + " VALUES('" + symbol + "'," + Convert.ToString(index + 1) + ",";
                runQuery += domBid.Price.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += domAsk.Price.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += domBid.Volume.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += domAsk.Volume.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += instrument.Trade.Price.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += instrument.Trade.Volume.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += "'" + serverTime.ToString("yyyy/MM/dd H:mm:ss.fff", CultureInfo.InvariantCulture) + "',";
                runQuery += "'" + DateTime.Now.ToString("yyyy/MM/dd H:mm:ss.fff", CultureInfo.InvariantCulture) + "',";
                runQuery += Convert.ToString(groupID) + ",";
                runQuery += "'" + userName + "');";

                if (index == 0)
                {
                    askPrice = domAsk.Price;
                    askVol = domAsk.Volume;
                    bidPrice = domBid.Price;
                    bidVol = domBid.Volume;
                }
            }
            //instrument.
            return runQuery;
        }

        public static string InsertData(String tableName, string symbolName,
                                       double bidPrice, int bidVolume,
                                       double askPrice, int askVolume,
                                       double tradePrice, int tradeVolume,
                                       bool isNew, DateTime timestamp, uint groupID, string userName, string tickType)
        {
            String query = "INSERT IGNORE INTO `" + tableName + "`";
            query += "(`Symbol`,`Bid`,`Ask`,`BidVol`,`AskVol`,`Trade`,`TradeVol`,`Time`, `TickType`, `TimeLocal`, `GroupID`,`UserName`)";
            String runQuery = "";
            runQuery += query + " VALUES('" + symbolName + "',";
            runQuery += bidPrice.ToString("G", CultureInfo.InvariantCulture) + ",";
            runQuery += askPrice.ToString("G", CultureInfo.InvariantCulture) + ",";
            runQuery += bidVolume.ToString("G", CultureInfo.InvariantCulture) + ",";
            runQuery += askVolume.ToString("G", CultureInfo.InvariantCulture) + ",";
            runQuery += tradePrice.ToString("G", CultureInfo.InvariantCulture) + ",";
            runQuery += tradeVolume.ToString("G", CultureInfo.InvariantCulture) + ",";
            runQuery += "'" + timestamp.ToString("yyyy-MM-dd H:mm:ss.fff", CultureInfo.InvariantCulture) + "', ";
            runQuery += "'" + tickType + "', ";
            runQuery += "'" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss.fff", CultureInfo.InvariantCulture) + "', ";
            runQuery += "'" + groupID.ToString("G", CultureInfo.InvariantCulture) + "',";
            runQuery += "'" + userName + "');";
            return runQuery;
        }
        
    }
}
