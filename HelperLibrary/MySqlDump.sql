CREATE DATABASE  IF NOT EXISTS `cashflow_alpha` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `cashflow_alpha`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: cashflow_alpha
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tab_accounts`
--

DROP TABLE IF EXISTS `tab_accounts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tab_accounts` (
  `acc_id` int NOT NULL AUTO_INCREMENT,
  `acc_name` varchar(45) DEFAULT NULL,
  `acc_iban` varchar(45) DEFAULT NULL,
  `acc_bic` varchar(45) DEFAULT NULL,
  `acc_acctype_id` int DEFAULT NULL,
  `acc_balance` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`acc_id`),
  KEY `sk_type_idx` (`acc_acctype_id`),
  CONSTRAINT `sk_acc_acctype` FOREIGN KEY (`acc_acctype_id`) REFERENCES `tab_acctypes` (`acctype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains registered user account information';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tab_acctypes`
--

DROP TABLE IF EXISTS `tab_acctypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tab_acctypes` (
  `acctype_id` int NOT NULL AUTO_INCREMENT,
  `acctype_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`acctype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains a specified List of user transaction account types';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tab_investments`
--

DROP TABLE IF EXISTS `tab_investments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tab_investments` (
  `inv_id` int NOT NULL AUTO_INCREMENT,
  `inv_amount` decimal(10,0) DEFAULT NULL,
  `inv_costaverage` decimal(10,0) DEFAULT NULL,
  `inv_value` decimal(10,0) DEFAULT NULL,
  `inv_isin` varchar(45) DEFAULT NULL,
  `inv_acc` int DEFAULT NULL,
  PRIMARY KEY (`inv_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains information to investment positions';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tab_partners`
--

DROP TABLE IF EXISTS `tab_partners`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tab_partners` (
  `partn_id` int NOT NULL AUTO_INCREMENT,
  `partn_name` varchar(150) DEFAULT NULL,
  `partn_iban` varchar(150) DEFAULT NULL,
  `partn_bic` varchar(45) DEFAULT NULL,
  `partn_bankcode` varchar(100) DEFAULT NULL,
  `partn_trxtype_id` int DEFAULT NULL,
  PRIMARY KEY (`partn_id`),
  KEY `sk_partner_trxtype_idx` (`partn_trxtype_id`),
  CONSTRAINT `sk_partner_trxtype` FOREIGN KEY (`partn_trxtype_id`) REFERENCES `tab_trxtypes` (`trxtype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=662 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tab_trx`
--

DROP TABLE IF EXISTS `tab_trx`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tab_trx` (
  `trx_id` int NOT NULL AUTO_INCREMENT,
  `trx_date` datetime DEFAULT NULL,
  `trx_amnt` decimal(10,2) DEFAULT NULL,
  `trx_currency` varchar(45) DEFAULT NULL,
  `trx_info` varchar(350) DEFAULT NULL,
  `trx_reference` varchar(350) DEFAULT NULL,
  `trx_partn_id` int DEFAULT NULL,
  `trx_acc_id` int DEFAULT NULL,
  `trx_trxtype_id` int DEFAULT NULL,
  `trx_invpos_id` int DEFAULT NULL,
  PRIMARY KEY (`trx_id`),
  KEY `sk_partner_idx` (`trx_partn_id`),
  KEY `sk_acc_idx` (`trx_acc_id`),
  KEY `sk_type_idx` (`trx_trxtype_id`),
  KEY `sk_invpos_idx` (`trx_invpos_id`),
  CONSTRAINT `sk_trx_acc` FOREIGN KEY (`trx_acc_id`) REFERENCES `tab_accounts` (`acc_id`),
  CONSTRAINT `sk_trx_invpos` FOREIGN KEY (`trx_invpos_id`) REFERENCES `tab_investments` (`inv_id`),
  CONSTRAINT `sk_trx_partner` FOREIGN KEY (`trx_partn_id`) REFERENCES `tab_partners` (`partn_id`),
  CONSTRAINT `sk_trx_type` FOREIGN KEY (`trx_trxtype_id`) REFERENCES `tab_trxtypes` (`trxtype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2492 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A table of all registered transactions';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tab_trxtypes`
--

DROP TABLE IF EXISTS `tab_trxtypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tab_trxtypes` (
  `trxtype_id` int NOT NULL AUTO_INCREMENT,
  `trxtype_name` varchar(45) DEFAULT NULL,
  `trxtype_budget` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`trxtype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains types of transactions and budgets';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `view_accounts`
--

DROP TABLE IF EXISTS `view_accounts`;
/*!50001 DROP VIEW IF EXISTS `view_accounts`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_accounts` AS SELECT 
 1 AS `Name`,
 1 AS `Type`,
 1 AS `Balance`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_partners`
--

DROP TABLE IF EXISTS `view_partners`;
/*!50001 DROP VIEW IF EXISTS `view_partners`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_partners` AS SELECT 
 1 AS `Partner ID`,
 1 AS `Partner Name`,
 1 AS `Transaction Category`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_trx`
--

DROP TABLE IF EXISTS `view_trx`;
/*!50001 DROP VIEW IF EXISTS `view_trx`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_trx` AS SELECT 
 1 AS `ID`,
 1 AS `Booking Date`,
 1 AS `Amount`,
 1 AS `Partner`,
 1 AS `Transaction Category`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `view_trxtypes`
--

DROP TABLE IF EXISTS `view_trxtypes`;
/*!50001 DROP VIEW IF EXISTS `view_trxtypes`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_trxtypes` AS SELECT 
 1 AS `Transaction Type`,
 1 AS `Budget`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `view_accounts`
--

/*!50001 DROP VIEW IF EXISTS `view_accounts`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_accounts` AS select `tab_accounts`.`acc_name` AS `Name`,`tab_acctypes`.`acctype_name` AS `Type`,`tab_accounts`.`acc_balance` AS `Balance` from (`tab_accounts` join `tab_acctypes`) where (`tab_accounts`.`acc_acctype_id` = `tab_acctypes`.`acctype_id`) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_partners`
--

/*!50001 DROP VIEW IF EXISTS `view_partners`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_partners` AS select `tab_partners`.`partn_id` AS `Partner ID`,`tab_partners`.`partn_name` AS `Partner Name`,`tab_trxtypes`.`trxtype_name` AS `Transaction Category` from (`tab_partners` left join `tab_trxtypes` on((`tab_trxtypes`.`trxtype_id` = `tab_partners`.`partn_trxtype_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_trx`
--

/*!50001 DROP VIEW IF EXISTS `view_trx`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_trx` AS select `tab_trx`.`trx_id` AS `ID`,`tab_trx`.`trx_date` AS `Booking Date`,`tab_trx`.`trx_amnt` AS `Amount`,`tab_partners`.`partn_name` AS `Partner`,`tab_trxtypes`.`trxtype_name` AS `Transaction Category` from ((`tab_trx` left join `tab_partners` on((`tab_partners`.`partn_id` = `tab_trx`.`trx_partn_id`))) left join `tab_trxtypes` on((`tab_trxtypes`.`trxtype_id` = `tab_trx`.`trx_trxtype_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `view_trxtypes`
--

/*!50001 DROP VIEW IF EXISTS `view_trxtypes`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `view_trxtypes` AS select `tab_trxtypes`.`trxtype_name` AS `Transaction Type`,`tab_trxtypes`.`trxtype_budget` AS `Budget` from `tab_trxtypes` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-11 17:07:12
