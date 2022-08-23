-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: cashflow_alpha
-- ------------------------------------------------------
-- Server version	8.0.28

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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains registered user account information';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tab_accounts`
--

LOCK TABLES `tab_accounts` WRITE;
/*!40000 ALTER TABLE `tab_accounts` DISABLE KEYS */;
INSERT INTO `tab_accounts` VALUES (1,'Sparkasse','xxxxxxxxxxx','WINSATWNXXX',1,7245.00),(28,'Arsch','yyyyyyyyy','asdasdasd',3,9999.00);
/*!40000 ALTER TABLE `tab_accounts` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains a specified List of user transaction account types';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tab_acctypes`
--

LOCK TABLES `tab_acctypes` WRITE;
/*!40000 ALTER TABLE `tab_acctypes` DISABLE KEYS */;
INSERT INTO `tab_acctypes` VALUES (1,'Giro'),(2,'Creditcard'),(3,'Depot'),(4,'Wallet'),(5,'Savings');
/*!40000 ALTER TABLE `tab_acctypes` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `tab_investments`
--

LOCK TABLES `tab_investments` WRITE;
/*!40000 ALTER TABLE `tab_investments` DISABLE KEYS */;
/*!40000 ALTER TABLE `tab_investments` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=311 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tab_partners`
--

LOCK TABLES `tab_partners` WRITE;
/*!40000 ALTER TABLE `tab_partners` DISABLE KEYS */;
INSERT INTO `tab_partners` VALUES (1,'_Cash',NULL,NULL,NULL,NULL),(2,'LANDGASTHOF LELL','','','20267',NULL),(3,'A1 Telekom Austria AG','AT251200008353193911','','12000',NULL),(4,'TOTAL SERVICE STATION','','','20267',NULL),(5,'MCDONALDS 01791','','','20267',NULL),(6,'MCDONALDS 130','','','20267',NULL),(7,'Nico Szawlowski','AT762026702012227514','WINSATWNXXX','20267',NULL),(8,'TABAK-TRAFIK KORNFELL','','','20267',NULL),(9,'GEVA','AT031500000641002829','OBKLAT2LXXX','15000',NULL),(10,'Erste Bank','AT052011140005191900','GIBAATWWXXX','20111',NULL),(11,'STG MOLLIE PAYMENTS','NL44ABNA0428063969','ABNANL2AXXX','',NULL),(12,'MCDONALDS 01642','','','20267',NULL),(13,'Grazer Wechselseitige Versicherung','AT233800000000051052','RZSTAT2GXXX','38000',NULL),(14,'AVANTI 8654/ EGGENDORF','','','20267',NULL),(15,'BEIM KOHLER','','','20267',NULL),(16,'MCDONALDS 01187','','','20267',NULL),(17,'Michael Szawlowski','AT662026700001301100','WINSATWNXXX','20267',NULL),(18,'ARAL STATION 284568102','','','20267',NULL),(19,'MOXY','','','20267',NULL),(20,'H&M FRANKFURT 1DE0201','','','20267',NULL),(21,'PEEK & CLOPPENBURG','','','20267',NULL),(22,'BIOTECH USA','','','20267',NULL),(23,'FRISCHEMARKT GEIGER','','','20267',NULL),(24,'LIDL DIENSTLEISTUNG','','','20267',NULL),(25,'MCDONALDS 01176','','','20267',NULL),(26,'SHELL 1936','','','20267',NULL),(27,'MCDONALDS 28','','','20267',NULL),(28,'Histo-Tech','AT093219500000914820','','32195',NULL),(29,'1. WR. NEUSTADTER FAHR','','','20267',NULL),(30,'BIKE EXPERT','','','20267',NULL),(31,'ENI SERVICE STATION 41','','','20267',NULL),(32,'BILLA AG/ABT. BILLA PL','','','20267',NULL),(33,'TRAFIK NAGELE','','','20267',NULL),(34,'MARIA LORETTO','','','20267',NULL),(35,'CASAG BADEN','','','20267',NULL),(36,'Lisa Marie Schuh','AT892026702001460571','WINSATWNXXX','20267',NULL),(37,'BILLA 3394','','','20267',NULL),(38,'CAFE+CO AT 282475','','','20267',NULL),(39,'TRAFIK HUBEL','','','20267',NULL),(40,'OBI BAU- UND HEIMWERKE','','','20267',NULL),(41,'TRAFIK GOTTFRIED','','','20267',NULL),(42,'JET 5198','','','20267',NULL),(43,'SUEDRING - APOTHEKE','','','20267',NULL),(44,'TQSR KLF GMBH','','','20267',NULL),(45,'BP 23','','','20267',NULL),(46,'RESTAURANT SALUD','','','20267',NULL),(47,'TURMOL 127','','','20267',NULL),(48,'RAG HANDELSGESELLSCHAF','','','20267',NULL),(49,'FA Österreich - NiederösterreichMitte','AT080100000005504295','BUNDATWWXXX','01000',NULL),(50,'SHELL ASPANG 2768','','','20267',NULL),(51,'TURMOL TANKAUTOMAT POT','','','20267',NULL),(52,'Habeler&Bauer','AT462026702000145249','','20267',NULL),(53,'BILLA 7223','','','20267',NULL),(54,'MCDONALDS 34','','','20267',NULL),(55,'TABAK TRAFIK THEISSBAC','','','20267',NULL),(56,'TABAKFACHGESCHAFT EBER','','','20267',NULL),(57,'JET 5079','','','20267',NULL),(58,'Michael Szawlowski und Alexandra Sz','AT662026700001301100','WINSATWNXXX','20267',NULL),(59,'BILLA 6120','','','20267',NULL),(60,'TRAFIK SENEKOWITSCH','','','20267',NULL),(61,'HB Fliesen','AT053477700009501420','','34777',NULL),(62,'TABAK TRAFIK PAUER','','','20267',NULL),(63,'TABAK TRAFIK RITTNAUER','','','20267',NULL),(64,'BILLA 3769','','','20267',NULL),(65,'CAFE+CO AT 281236','','','20267',NULL),(66,'COCA COLA HBC AUSTRIA','','','20267',NULL),(67,'KYOTO REISSPEZIALITAET','','','20267',NULL),(68,'TABAKFACHGESCHAFT MULL','','','20267',NULL),(69,'MCDONALDS 95','','','20267',NULL),(70,'GASTHAUS IM LANDHAUSHO','','','20267',NULL),(71,'AVANTI 9506/ POTTENDOR','','','20267',NULL),(72,'TABAK TRAFIK SILVIA DA','','','20267',NULL),(73,'TURMOL TANKAUTOMAT WIE','','','20267',NULL),(74,'Klarna Bank AB publ','AT511910000044039003','','19100',NULL),(75,'BH WIENER NEUSTADT','','','20267',NULL),(76,'BILLA 3561','','','20267',NULL),(77,'MCDONALDS 148','','','20267',NULL),(78,'BILLA 9860','','','20267',NULL),(79,'AMAZON PAYMENTS EUROPE S.C.A.','DE87300308801908262006','TUBDDEDDXXX','',NULL),(80,'MEDIA MARKT 2700','','','20267',NULL),(81,'HARTLAUER FIL.74','','','20267',NULL),(82,'AVANTI 8024/ OEYNHAUSE','','','20267',NULL),(83,'TABAK TRAFIK MARIO KRA','','','20267',NULL),(84,'QUICK SERVICE RESTAURA','','','20267',NULL),(85,'BILLA DANKT','','','20267',NULL),(86,'TABAK-TRAFIK TSCHIDA','','','20267',NULL),(87,'TABAK TRAFIK GUERMAH','','','20267',NULL),(88,'TRAFIK GNEIST','','','20267',NULL),(89,'TRAFIK HOELZL','','','20267',NULL),(90,'TURMOL TANKAUTOMAT TRI','','','20267',NULL),(91,'DISTRIBUTORE AGIP','','','20267',NULL),(92,'SHELL VOELKERMARKT 873','','','20267',NULL),(93,'THUISBEZORGD.NL BV','NL31ABNA0494688556','','',NULL),(94,'GEVA Elektronik-HandelsgmbH','AT453225000000202499','RLNWATWWGTD','32250',NULL),(95,'TABAK TRAFIK PETTINGER','','','20267',NULL),(96,'NAH & FRISCH BAUMANN','','','20267',NULL),(97,'JET 6036','','','20267',NULL),(98,'FIVE GUYS MILLENNIUM C','','','20267',NULL),(99,'Richard Strabl','AT071200050230123184','','12000',NULL),(100,'Erzdiözese Wien','AT853100000200107375','','31000',NULL),(101,'CAFE WINTER','','','20267',NULL),(102,'TURMOL 328','','','20267',NULL),(103,'TABAK TRAFIK STICH','','','20267',NULL),(104,'BILLA 3059','','','20267',NULL),(105,'XXXLUTZ 8816','','','20267',NULL),(106,'CCC SHOES & BAGS','','','20267',NULL),(107,'TRAFIK JOBSTL','','','20267',NULL),(108,'OLYMPH GMBH','','','20267',NULL),(109,'SPAR DANKT 4728','','','20267',NULL),(110,'Nico Szawlowskis Depot Konto','AT481948031014980820','','19480',NULL),(111,'BILLA 6325','','','20267',NULL),(112,'JET 5547','','','20267',NULL),(113,'JET 5680','','','20267',NULL),(114,'FORSTINGER 085','','','20267',NULL),(115,'MCDONALDS 237','','','20267',NULL),(116,'Lena-Marie Stollwitzer','AT192026702001292081','WINSATWNXXX','20267',NULL),(117,'WINKLER KJL','','','20267',NULL),(118,'BILLA 0255','','','20267',NULL),(119,'BILLA 3100','','','20267',NULL),(120,'MCDONALDS 218','','','20267',NULL),(121,'CHRISTINE BLEHA','','','20267',NULL),(122,'TRAFIK KLIESSPIESS','','','20267',NULL),(123,'BILLA 2071','','','20267',NULL),(124,'BILLA 7393','','','20267',NULL),(125,'PENSION POLZL','','','20267',NULL),(126,'MCDONALDS 128','','','20267',NULL),(127,'Stadt Wien, MA6-BA32, Strafen','AT131200010022813611','','12000',NULL),(128,'JET 5568','','','20267',NULL),(129,'OMV 9538','','','20267',NULL),(130,'TRAFIK SEDERL','','','20267',NULL),(131,'TURMOL 340','','','20267',NULL),(132,'TRAFIK SPORER','','','20267',NULL),(133,'BP TANKSTELLE','','','20267',NULL),(134,'TRAFIK MARINKOVIC','','','20267',NULL),(135,'AMAZON EU S.A R.L., NIEDERLASSUNG DEUTSCHLAND','DE93300308800013441006','TUBDDEDDXXX','',NULL),(136,'TURMOL TANKAUTOMAT OEY','','','20267',NULL),(137,'OMV 1591','','','20267',NULL),(138,'SAMUEL RESTAURANT GMBH','','','20267',NULL),(139,'Bezirkshauptmannschaft Neunkirchen','AT553236700400000232','','32367',NULL),(140,'Südraum Genossenschaft','AT685400000500763297','','54000',NULL),(141,'AVANTI 7651/ WIEN 1210','','','20267',NULL),(142,'OMV 9503','','','20267',NULL),(143,'CONRAD ELECTRONIC','','','20267',NULL),(144,'Lukas Hanzl','AT461921080128767748','','19210',NULL),(145,'PPRO Payment Services SA','DE47700111104101891181','DEKTDE7GXXX','',NULL),(146,'TABAK TRAFIK PETRI','','','20267',NULL),(147,'BILLA 3659','','','20267',NULL),(148,'MCDONALDS 46','','','20267',NULL),(149,'BILLA 7004','','','20267',NULL),(150,'KRAUSE NAH U. FRISCH','','','20267',NULL),(151,'Checkmate Commerce GmbH','DE07700111106022569889','','',NULL),(152,'ENI SERVICESTATION 801','','','20267',NULL),(153,'TRAFIK BAUER','','','20267',NULL),(154,'TRAFIK HUBER WR. NEUST','','','20267',NULL),(155,'MCDONALDS 88','','','20267',NULL),(156,'TOPF & KOPF RAUCHERBED','','','20267',NULL),(157,'PayPal (Europe) S.a.r.l. et Cie., S.C.A.','DE88500700100175526303','DEUTDEFFXXX','',NULL),(158,'Global Collect BV','AT571910000040731001','','19100',NULL),(159,'ALEXANDRA SZAWLOWSKI','AT082026709999770465','WINSATWNXXX','20267',NULL),(160,'iBuyPower','DE15320500000000256149','','',NULL),(161,'Benjamin Hornung','AT503204500004316428','RLNWATWWBAD','32045',NULL),(162,'Cyberport GmbH','DE73680800300723303600','','',NULL),(163,'SKRILL.COM SKRILL_1305','','','20267',NULL),(164,'SKR*SKRILL_1305','','','20267',NULL),(165,'Paysafe Payment Solutions','DE69700111105100905037','','',NULL),(166,'Lena Weichselbaumer','AT754300025284120000','','43000',NULL),(167,'MERKUR 9910','','','20267',NULL),(168,'JET 0198','','','20267',NULL),(169,'MEIN SCHNITZEL','','','20267',NULL),(170,'F. LEITNER MINERALOELE','','','20267',NULL),(171,'WEI\'S WOK','','','20267',NULL),(172,'HOFA','DE06663500360007115927','','',NULL),(173,'TABAK-TRAFIK','','','20267',NULL),(174,'SPAR DANKT 4728 BADEN','','','20267',NULL),(175,'Sparbuch','AT592026700610089716','','20267',NULL),(176,'TANKAUTOMAT POETTSCHIN','','','20267',NULL),(177,'TURMOEL 173','','','20267',NULL),(178,'TABAK TRAFIK','','','20267',NULL),(179,'TOPF & KOPF','','','20267',NULL),(180,'INTERSPORT','','','20267',NULL),(181,'SCHNELL 2700','','','20267',NULL),(182,'INTERSPAR DANKT','','','20267',NULL),(183,'SUPERKOSHER','','','20267',NULL),(184,'MEDIA MARKT','','','20267',NULL),(185,'DEWESOFT KCW GMBH','AT221700000119003768','BFKKAT2KXXX','17000',NULL),(186,'STROECK 3083','','','20267',NULL),(187,'HOFER DANKT','','','20267',NULL),(188,'Daniel Riemer','AT721400027310930577','BAWAATWWXXX','14000',NULL),(189,'TRAFIKKARTEN','','','20267',NULL),(190,'TABAK TRAFIK WIEN 1120','','','20267',NULL),(191,'BAUHAUS 793 BAD','','','20267',NULL),(192,'PENNY DANKT','','','20267',NULL),(193,'HM AT0101 VOESENDORF','','','20267',NULL),(194,'JACK & JONES','','','20267',NULL),(195,'FREILICHTMUS','','','20267',NULL),(196,'KLIPP FRISOR GMBH','','','20267',NULL),(197,'JET 2604','','','20267',NULL),(198,'MEIN SCHNITZ','','','20267',NULL),(199,'TANKSTELLE 207 BADEN','','','20267',NULL),(200,'KOECKENBAUER','','','20267',NULL),(201,'Moebelix GmbH','AT023400000402639763','','34000',NULL),(202,'NAH & FRISCH','','','20267',NULL),(203,'NTRY Ticketing OG','AT043445580004068813','','34455',NULL),(204,'TRAFIK ART','','','20267',NULL),(205,'HM AT0014 WR NEUSTADT','','','20267',NULL),(206,'BP TANKSTELLE WIEN','','','20267',NULL),(207,'KORNFELL','','','20267',NULL),(208,'Oesterreichisches Rotes Kreuz Landesverband Niederoesterreich','AT042011100002000814','GIBAATWWXXX','20111',NULL),(209,'BLUMEN HANDELS GMBH','','','20267',NULL),(210,'AMS NIEDEROESTERREICH','AT220100000005650125','BUNDATWWXXX','01000',NULL),(211,'TRAFIK STURM','','','20267',NULL),(212,'1023 GIGASP','','','20267',NULL),(213,'Zivildienstserviceagentur','AT750100000005060090','','01000',NULL),(214,'Suraway Ltd.','DE22101308008000104874','','',NULL),(215,'MERKUR DANKT','','','20267',NULL),(216,'Florian Fux','AT073293700002620383','','32937',NULL),(217,'DM-FIL. 0226','','','20267',NULL),(218,'TRAFIK GNEIS','','','20267',NULL),(219,'AVANTI 8772/ WIENER NE','','','20267',NULL),(220,'JET 2700','','','20267',NULL),(221,'BM F.INNERES            DVR:0000051','AT330100000005020009','BUNDATWWXXX','01000',NULL),(222,'SUBWAY WIENER NEUSTADT','','','20267',NULL),(223,'SPAR DANKT 4076','','','20267',NULL),(224,'MY SCHNITZEL','','','20267',NULL),(225,'OEBB TICKET WIENER','','','20267',NULL),(226,'WRLINIEN693','','','20267',NULL),(227,'Daniel Gruber','AT863219500001924950','RLNWATWWASP','32195',NULL),(228,'SCHNEIDEWERK E.U.','','','20267',NULL),(229,'Necror UG haftungsbeschrae','DE11101308008000101774','','',NULL),(230,'Adyen B.V.','DE25700111105100580006','','',NULL),(231,'HEURIGEN REST WITTMANN','','','20267',NULL),(232,'STURM','','','20267',NULL),(233,'BEIM KOEHLER','','','20267',NULL),(234,'SPAR DANKT 4620','','','20267',NULL),(235,'ASIA NUEDEL','','','20267',NULL),(236,'MANG THAI','','','20267',NULL),(237,'Michael Scheibenreif','AT603293700000150003','','32937',NULL),(238,'DER MANN','','','20267',NULL),(239,'SPAR DANKT 4699','','','20267',NULL),(240,'SHELL FEUERWERKSANSTAL','','','20267',NULL),(241,'NEXT WR. NEUSTADT 2700','','','20267',NULL),(242,'Tipico Co. Ltd','DE02512308000000063343','','',NULL),(243,'TABAKFACHGES','','','20267',NULL),(244,'SONNENAPOTHE','','','20267',NULL),(245,'PPRO Financial Ltd','DE59202208000000012785','SXPYDEHH','',NULL),(246,'OMV 9503/ WR NEUSTADT','','','20267',NULL),(247,'TRAFIK EBERT','','','20267',NULL),(248,'MCDONALDS218','','','20267',NULL),(249,'Benjamin Czasch','AT962020501001162708','','20205',NULL),(250,'SCHNITZEL','','','20267',NULL),(251,'LIDL DANKT','','','20267',NULL),(252,'SPAR DANKT 4824 WIEN','','','20267',NULL),(253,'PEARLE OPTIK WIENER','','','20267',NULL),(254,'PIZZERIA DA SERGIO','','','20267',NULL),(255,'CENTER INFO','','','20267',NULL),(256,'SPAR DANKT 4223','','','20267',NULL),(257,'SPAR DANKT 4488','','','20267',NULL),(258,'TRAFIK ROCH','','','20267',NULL),(259,'EUROSPAR DANKT 4602','','','20267',NULL),(260,'EUROSPAR DANKT 4041','','','20267',NULL),(261,'SPORER','','','20267',NULL),(262,'VS-Verrechnungskonto','AT092010040002501103','GIBAATWGXXX','20100',NULL),(263,'SPAR DANKT 4673','','','20267',NULL),(264,'TVE elektronische Systeme GMBH','SK9283700000002301557928','OBKLSKBAXXX','',NULL),(265,'ENI 8116','','','20267',NULL),(266,'TRAFIKLINSHA','','','20267',NULL),(267,'RAG HANDELS GMBH','','','20267',NULL),(268,'WorldPay Customer Payments','AT322011130050270855','GIBAATWW','20111',NULL),(269,'Mobiltec 24 GmbH','DE57860100900237326905','','',NULL),(270,'Lea-Carmen Apollonia Tiess','AT052026702001370127','WINSATWNXXX','20267',NULL),(271,'ETSAN','','','20267',NULL),(272,'DINHOBL&MUELLER GASTRO','','','20267',NULL),(273,'LEBURGER','','','20267',NULL),(274,'Lukas Zdichynec','AT362020501001035748','SPBDAT21XXX','20205',NULL),(275,'RESTAURANT HU WIENER','','','20267',NULL),(276,'DISKONTTANKSTELLE LAND','','','20267',NULL),(277,'BLEHA','','','20267',NULL),(278,'SUB Betriebs- und Event GmbH','AT433293700000064949','RLNWATWWWRN','',NULL),(279,'KRAUSE','','','20267',NULL),(280,'TANKSTELLE ZILLINGTAL','','','20267',NULL),(281,'Trafik Gneist Wiener','','','20267',NULL),(282,'Finanzamt               DVR 0009334Neunkirchen Wr. Neustadt','AT650100000005504336','BUNDATWWXXX','',NULL),(283,'MMOGA Limited','DE11700111104003977604','','',NULL),(284,'TVE-Elektronische Systeme GmbH','AT181200000648291201','BKAUATWWXXX','',NULL),(285,'PAGRO 2700','','','20267',NULL),(286,'B D CERPACI STANICE','','','20267',NULL),(287,'LET IT ROLL MILOVICE','','','20267',NULL),(288,'SHELL 8122 HAVLICKUV','','','20267',NULL),(289,'BK Hate Freeport','','','20267',NULL),(290,'DON PEALO PODEBRADY','','','20267',NULL),(291,'SPAR DANKT 4207','','','20267',NULL),(292,'MCDONALDS PRAHA 12000','','','20267',NULL),(293,'PRAHA FREYOVA PRAHA 9','','','20267',NULL),(294,'Aleyna Gueldogan','AT612011129323295200','GIBAATWWXXX','20111',NULL),(295,'TRAFIK GUENT','','','20267',NULL),(296,'March. Raststation Wor','','','20267',NULL),(297,'SUP. COOP RIVA DEL GAR','','','20267',NULL),(298,'Vanessa Höller-Reinthaler','AT622011128922836502','GIBAATWWXXX','20111',NULL),(299,'MCDONALDS','','','20267',NULL),(300,'Das Futterhaus 7001','','','20267',NULL),(301,'FORSTINGER','','','20267',NULL),(302,'BURGER KING WIENER','','','20267',NULL),(303,'NANU NANA 1375 Wiener','','','20267',NULL),(304,'Hugs GmbH Wiener','','','20267',NULL),(305,'HARAMER','','','20267',NULL),(306,'MCDONALDS 3','','','20267',NULL),(307,'CIVITAS','','','20267',NULL),(308,'Burgenland SVA 1 - Strafamt','AT840100000005020061','','',NULL),(309,'CASAG BADEN BADEN 2500','','','20267',NULL),(310,'CUISINO BADEN 2500','','','20267',NULL);
/*!40000 ALTER TABLE `tab_partners` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tab_trx`
--

DROP TABLE IF EXISTS `tab_trx`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tab_trx` (
  `trx_id` int NOT NULL AUTO_INCREMENT,
  `trx_date` datetime DEFAULT NULL,
  `trx_amnt` decimal(10,0) DEFAULT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='A table of all registered transactions';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tab_trx`
--

LOCK TABLES `tab_trx` WRITE;
/*!40000 ALTER TABLE `tab_trx` DISABLE KEYS */;
/*!40000 ALTER TABLE `tab_trx` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tab_trxtypes`
--

DROP TABLE IF EXISTS `tab_trxtypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tab_trxtypes` (
  `trxtype_id` int NOT NULL AUTO_INCREMENT,
  `trxtype_name` varchar(45) DEFAULT NULL,
  `trxtype_budget` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`trxtype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Contains types of transactions and budgets';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tab_trxtypes`
--

LOCK TABLES `tab_trxtypes` WRITE;
/*!40000 ALTER TABLE `tab_trxtypes` DISABLE KEYS */;
INSERT INTO `tab_trxtypes` VALUES (1,'Lebensmittel','300'),(2,'Transport','500'),(3,'Wohn Nebenkosten','700');
/*!40000 ALTER TABLE `tab_trxtypes` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Temporary view structure for view `view_trxtypes`
--

DROP TABLE IF EXISTS `view_trxtypes`;
/*!50001 DROP VIEW IF EXISTS `view_trxtypes`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `view_trxtypes` AS SELECT 
 1 AS `Transaction Type`*/;
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
/*!50001 VIEW `view_trxtypes` AS select `tab_trxtypes`.`trxtype_name` AS `Transaction Type` from `tab_trxtypes` */;
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

-- Dump completed on 2022-08-23 21:55:34
