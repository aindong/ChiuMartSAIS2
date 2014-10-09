-- phpMyAdmin SQL Dump
-- version 4.1.6
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 09, 2014 at 08:01 AM
-- Server version: 5.6.16
-- PHP Version: 5.5.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `chuisais`
--

-- --------------------------------------------------------

--
-- Table structure for table `basyo`
--

CREATE TABLE IF NOT EXISTS `basyo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `transId` int(11) NOT NULL,
  `clientId` int(11) NOT NULL,
  `basyoTransCount` int(11) NOT NULL,
  `basyoYellowCount` int(11) NOT NULL,
  `basyoTransReturned` int(11) NOT NULL,
  `basyoYellowReturned` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `basyo`
--

INSERT INTO `basyo` (`id`, `transId`, `clientId`, `basyoTransCount`, `basyoYellowCount`, `basyoTransReturned`, `basyoYellowReturned`) VALUES
(1, 2014100009, 1, 10, 1, 0, 0),
(2, 2014100010, 0, 5, 2, 0, 0),
(3, 2014100015, 1, 10, 0, 0, 0),
(4, 2014110016, 1, 0, 0, 0, 0),
(5, 2014110017, 2, 0, 0, 0, 0),
(6, 2014110018, 4, 0, 0, 0, 0),
(7, 2014110019, 1, 10, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `categoryId` int(11) NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(65) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`categoryId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=24 ;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`categoryId`, `categoryName`, `created_date`, `updated_date`, `status`) VALUES
(1, 'Flour', '2014-08-14 11:24:04', '2014-08-14 11:24:04', 'active'),
(2, 'P.P Plastic', '2014-08-14 11:24:12', '2014-08-14 11:24:12', 'active'),
(3, 'Sugar', '2014-08-14 11:24:18', '2014-08-14 11:24:18', 'active'),
(4, 'Bihon', '2014-08-14 11:24:24', '2014-08-14 11:24:24', 'active'),
(5, 'Plastic Cup', '2014-08-14 11:24:45', '2014-08-14 11:24:45', 'active'),
(6, 'Baking Powder', '2014-08-14 11:24:54', '2014-08-14 11:24:54', 'active'),
(7, 'Plastic', '2014-08-14 11:25:01', '2014-08-14 11:25:01', 'active'),
(8, 'Dessicated Coconut', '2014-08-14 11:25:19', '2014-08-14 11:25:19', 'active'),
(9, 'Evap', '2014-08-14 11:25:27', '2014-08-14 11:25:27', 'active'),
(10, 'Bread Improver', '2014-08-14 11:25:34', '2014-08-14 11:25:34', 'active'),
(11, 'Cheese', '2014-08-14 11:25:42', '2014-08-14 11:25:42', 'active'),
(12, 'Milk', '2014-08-14 11:25:46', '2014-08-14 11:25:46', 'active'),
(13, 'Food Color', '2014-08-14 11:25:59', '2014-08-14 11:25:59', 'active'),
(14, 'Glutinous Flour', '2014-08-14 11:26:27', '2014-08-14 11:26:27', 'active'),
(15, 'Cassava Flour', '2014-08-14 11:26:32', '2014-08-14 11:26:32', 'active'),
(16, 'Sando Bag', '2014-08-14 11:26:37', '2014-08-14 11:26:37', 'active'),
(17, 'Pet Bottle', '2014-08-14 11:27:06', '2014-08-14 11:27:06', 'active'),
(18, 'Powder Milk', '2014-08-14 11:27:14', '2014-08-14 11:27:14', 'active'),
(19, 'Oil', '2014-08-14 11:27:20', '2014-08-14 11:27:20', 'active'),
(20, 'Lard', '2014-08-14 11:27:22', '2014-08-14 11:27:22', 'active'),
(21, 'Margarine', '2014-08-14 11:27:28', '2014-08-14 11:27:28', 'active'),
(22, 'Paper Supot', '2014-08-14 11:27:45', '2014-08-14 11:27:45', 'active'),
(23, 'Yeast', '2014-08-14 11:46:11', '2014-08-14 11:46:11', 'active');

-- --------------------------------------------------------

--
-- Table structure for table `cheque`
--

CREATE TABLE IF NOT EXISTS `cheque` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `chequeNo` varchar(20) NOT NULL,
  `chequeName` varchar(150) NOT NULL,
  `chequeBank` varchar(50) NOT NULL,
  `chequeBranch` varchar(50) NOT NULL,
  `chequeAmount` double NOT NULL,
  `chequeDate` datetime NOT NULL,
  `chequeStatus` varchar(20) NOT NULL DEFAULT 'Cleared',
  `status` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `cheque`
--

INSERT INTO `cheque` (`id`, `chequeNo`, `chequeName`, `chequeBank`, `chequeBranch`, `chequeAmount`, `chequeDate`, `chequeStatus`, `status`) VALUES
(1, '123-123-123', 'Test Test', 'BPI', 'Tarlac', 5000, '2014-09-09 00:00:00', 'Cleared', 'active'),
(3, '123125123123', 'ALLEO INDONG', 'BDO', 'TARLAC', 4600, '2014-09-03 00:00:00', 'Cleared', 'inactive'),
(4, '123125123123', 'ALLEO INDONG', 'BDO', 'TARLAC', 4600, '2014-09-03 00:00:00', 'Cleared', 'inactive'),
(5, '12312314123', 'ALLEO INDONG', 'BDO', 'TARLAC', 4600, '2014-09-03 00:00:00', 'Cleared', 'inactive'),
(6, '', '', '', '', 150, '2014-09-03 00:00:00', 'Cleared', 'inactive'),
(7, '123', 'aaa', 'aa', 'aa', 1900, '2014-09-11 00:00:00', 'Cleared', 'active');

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE IF NOT EXISTS `client` (
  `clientId` int(11) NOT NULL AUTO_INCREMENT,
  `clientName` varchar(50) NOT NULL,
  `clientContact` varchar(20) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(10) NOT NULL,
  `clientAddress` varchar(200) NOT NULL,
  PRIMARY KEY (`clientId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`clientId`, `clientName`, `clientContact`, `created_date`, `updated_date`, `status`, `clientAddress`) VALUES
(1, 'Alma Corpuz', '2222', '2014-08-14 13:43:48', '2014-08-14 13:43:48', 'active', 'villasis'),
(2, 'Analie Pineda', '', '2014-08-14 13:44:56', '2014-08-14 13:44:56', 'active', 'Pangasinan'),
(3, 'Cueva''s Bakery', '', '2014-08-14 13:46:16', '2014-08-14 13:46:16', 'active', 'Villasis'),
(4, 'test', '123456', '2014-08-16 02:25:22', '2014-08-16 02:25:22', 'active', 'awww');

-- --------------------------------------------------------

--
-- Table structure for table `logs`
--

CREATE TABLE IF NOT EXISTS `logs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `relationId` int(11) NOT NULL,
  `clientId` int(11) NOT NULL,
  `supplierId` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `quantity` double NOT NULL,
  `unit_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `price` double NOT NULL,
  `paymentMethod` varchar(30) NOT NULL,
  `log_type` varchar(50) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=22 ;

--
-- Dumping data for table `logs`
--

INSERT INTO `logs` (`id`, `relationId`, `clientId`, `supplierId`, `username`, `quantity`, `unit_id`, `product_id`, `price`, `paymentMethod`, `log_type`, `created_date`) VALUES
(1, 19, 1, 0, 'Alleo', 10, 10, 19, 0, '', 'transaction', '2014-10-04 22:31:00'),
(2, 19, 2, 2, 'Alleo', 20, 10, 19, 0, '', 'transaction', '2014-10-04 23:01:42'),
(3, 19, 4, 0, 'Alleo', 5, 10, 19, 0, '', 'transaction', '2014-10-04 23:02:02'),
(4, 19, 2, 0, 'Alleo', 100, 10, 19, 0, '', 'transaction', '2014-10-08 21:52:43'),
(5, 18, 1, 0, 'Alleo', 100, 1, 18, 0, '', 'transaction', '2014-10-08 21:54:08'),
(6, 11, 3, 0, 'Alleo', 100, 7, 11, 0, '', 'transaction', '2014-10-08 21:54:23'),
(7, 27, 1, 0, 'Alleo', 10, 8, 27, 0, '', 'transaction', '2014-10-08 21:56:01'),
(8, 2, 2, 0, 'Alleo', 100, 1, 2, 0, '', 'transaction', '2014-10-08 21:56:18'),
(9, 3, 2, 0, 'Alleo', 100, 1, 3, 0, '', 'transaction', '2014-10-08 21:56:57'),
(10, 29, 2, 0, 'Alleo', 100, 4, 29, 0, '', 'transaction', '2014-10-08 21:57:41'),
(11, 30, 2, 0, 'Alleo', 100, 1, 30, 0, '', 'transaction', '2014-10-08 21:57:43'),
(12, 15, 3, 0, 'Alleo', 10, 1, 15, 0, '', 'transaction', '2014-10-08 21:59:12'),
(13, 17, 3, 0, 'Alleo', 10, 10, 17, 0, '', 'transaction', '2014-10-08 21:59:12'),
(14, 4, 3, 0, 'Alleo', 10, 7, 4, 0, '', 'transaction', '2014-10-08 21:59:13'),
(15, 5, 3, 0, 'Alleo', 10, 10, 5, 0, '', 'transaction', '2014-10-08 21:59:13'),
(16, 27, 1, 0, 'Alleo', 10, 8, 27, 0, '', 'transaction', '2014-10-08 22:39:00'),
(17, 2014100015, 1, 0, 'Alleo', 0, 0, 0, 200, 'Cash', 'Balance', '2014-10-09 12:35:21'),
(18, 2014100012, 2, 0, 'Alleo', 0, 0, 0, 200, 'Cash', 'Balance', '2014-10-09 13:12:05'),
(19, 2014100015, 1, 0, 'Alleo', 0, 0, 0, 400, 'Cash', 'Balance', '2014-10-09 13:20:21'),
(20, 2014100012, 2, 0, 'Alleo', 0, 0, 0, 10, 'Cash', 'Balance', '2014-10-09 13:27:08'),
(21, 2014100012, 2, 0, 'Alleo', 0, 0, 0, 20, 'Cash', 'Balance', '2014-10-09 13:28:05');

-- --------------------------------------------------------

--
-- Table structure for table `or`
--

CREATE TABLE IF NOT EXISTS `or` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ornumber` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=20 ;

--
-- Dumping data for table `or`
--

INSERT INTO `or` (`id`, `ornumber`) VALUES
(1, 2014090001),
(2, 2014100003),
(3, 2014100004),
(4, 2014100005),
(5, 2014100006),
(6, 2014100007),
(7, 2014100008),
(8, 2014100009),
(9, 2014100009),
(10, 2014100010),
(11, 2014100011),
(12, 2014100012),
(13, 2014100013),
(14, 2014100014),
(15, 2014100015),
(16, 2014110016),
(17, 2014110017),
(18, 2014110018),
(19, 2014110019);

-- --------------------------------------------------------

--
-- Table structure for table `permission`
--

CREATE TABLE IF NOT EXISTS `permission` (
  `permissionId` int(11) NOT NULL AUTO_INCREMENT,
  `role` varchar(150) NOT NULL,
  `products` int(11) NOT NULL,
  `categories` int(11) NOT NULL,
  `units` int(11) NOT NULL,
  `suppliers` int(11) NOT NULL,
  `permission` int(11) NOT NULL,
  `clients` int(11) NOT NULL,
  `users` int(11) NOT NULL,
  `pos` int(11) NOT NULL,
  `inventorymonitoring` int(11) NOT NULL,
  `purchaseorder` int(11) NOT NULL,
  `chequemonitoring` int(11) NOT NULL,
  `inventoryreport` int(11) NOT NULL,
  `salesreport` int(11) NOT NULL,
  `usersreport` int(11) NOT NULL,
  `logsreport` int(11) NOT NULL,
  `clientreport` int(11) NOT NULL,
  `supplierreport` int(11) NOT NULL,
  `systemutilities` int(11) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(20) NOT NULL,
  PRIMARY KEY (`permissionId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `permission`
--

INSERT INTO `permission` (`permissionId`, `role`, `products`, `categories`, `units`, `suppliers`, `permission`, `clients`, `users`, `pos`, `inventorymonitoring`, `purchaseorder`, `chequemonitoring`, `inventoryreport`, `salesreport`, `usersreport`, `logsreport`, `clientreport`, `supplierreport`, `systemutilities`, `created_date`, `updated_date`, `status`) VALUES
(1, 'Administrator', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, '2014-08-20 00:12:58', '2014-08-20 00:12:58', 'active'),
(2, 'test', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, '2014-08-20 06:51:49', '2014-08-20 06:51:49', 'inactive'),
(3, 'Manager', 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, '2014-09-03 15:23:53', '2014-09-03 15:23:53', 'active');

-- --------------------------------------------------------

--
-- Table structure for table `po`
--

CREATE TABLE IF NOT EXISTS `po` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `poId` varchar(20) NOT NULL,
  `productId` int(11) NOT NULL,
  `supplierId` int(11) NOT NULL,
  `poDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `qty` int(11) NOT NULL,
  `unitId` int(11) NOT NULL,
  `poStatus` varchar(20) NOT NULL,
  `status` varchar(25) NOT NULL,
  `oldPrice` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=23 ;

--
-- Dumping data for table `po`
--

INSERT INTO `po` (`id`, `poId`, `productId`, `supplierId`, `poDate`, `qty`, `unitId`, `poStatus`, `status`, `oldPrice`) VALUES
(1, '0001', 28, 2, '2014-09-03 01:24:09', 100, 8, 'Verified', 'active', 0),
(2, '0002', 27, 3, '2014-09-03 01:24:54', 10, 8, 'Verified', 'active', 0),
(3, '0002', 11, 3, '2014-09-03 01:25:01', 10, 7, 'Verified', 'active', 0),
(4, '0002', 19, 3, '2014-09-03 01:25:07', 10, 10, 'Verified', 'active', 0),
(5, '0003', 11, 3, '2014-09-03 14:27:30', 2, 7, 'Delivered', 'active', 0),
(6, '0004', 11, 3, '2014-09-03 14:28:02', 2, 7, 'Verified', 'active', 0),
(7, '0005', 31, 1, '2014-09-03 15:32:13', 15, 11, 'Delivered', 'active', 0),
(8, '0006', 19, 1, '2014-09-11 16:02:02', 100, 10, 'Delivered', 'active', 0),
(9, '0007', 19, 1, '2014-09-23 23:17:42', 100, 10, 'Delivered', 'active', 40),
(10, '0008', 19, 3, '2014-09-24 00:36:52', 100, 10, 'Delivered', 'active', 40),
(11, '0009', 19, 2, '2014-10-08 21:52:41', 100, 10, 'Verified', 'active', 40),
(12, '0010', 18, 1, '2014-10-08 21:54:06', 100, 1, 'Delivered', 'active', 400),
(13, '0011', 11, 3, '2014-10-08 21:54:22', 100, 7, 'Delivered', 'active', 1900),
(14, '0012', 27, 1, '2014-10-08 21:56:00', 10, 8, 'Delivered', 'active', 120),
(15, '0013', 2, 2, '2014-10-08 21:56:17', 100, 1, 'Verified', 'active', 120),
(16, '0014', 3, 2, '2014-10-08 21:56:56', 100, 1, 'Delivered', 'active', 175),
(17, '0015', 29, 2, '2014-10-08 21:57:40', 100, 4, 'Delivered', 'active', 4),
(18, '0015', 30, 2, '2014-10-08 21:57:41', 100, 1, 'Delivered', 'active', 40),
(19, '0016', 15, 3, '2014-10-08 21:59:12', 10, 1, 'Delivered', 'active', 40),
(20, '0016', 17, 3, '2014-10-08 21:59:12', 10, 10, 'Delivered', 'active', 400),
(21, '0016', 4, 3, '2014-10-08 21:59:12', 10, 7, 'Delivered', 'active', 900),
(22, '0016', 5, 3, '2014-10-08 21:59:13', 10, 10, 'Delivered', 'active', 270);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `productId` int(11) NOT NULL AUTO_INCREMENT,
  `productName` varchar(250) NOT NULL,
  `categoryId` int(11) NOT NULL,
  `productPrice` double NOT NULL,
  `unitId` int(11) NOT NULL,
  `supplierPrice` double NOT NULL DEFAULT '0',
  `productStock` int(11) NOT NULL,
  `productSafetyStock` int(11) NOT NULL,
  `created_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`productId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=32 ;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`productId`, `productName`, `categoryId`, `productPrice`, `unitId`, `supplierPrice`, `productStock`, `productSafetyStock`, `created_time`, `updated_time`, `status`) VALUES
(1, '4 x 9 - 02 swan', 2, 10, 11, 8, 210, 20, '2014-08-14 11:36:56', '2014-08-14 11:36:56', 'active'),
(2, 'Bihon 10 kg.', 4, 150, 1, 120, 140, 20, '2014-08-14 11:37:37', '2014-08-14 11:37:37', 'active'),
(3, 'Bihon 12 kg.', 4, 200, 1, 175, 150, 30, '2014-08-14 11:38:11', '2014-08-14 11:38:11', 'active'),
(4, '1st Farmers Wash', 3, 1000, 7, 900, 115, 30, '2014-08-14 11:38:58', '2014-08-14 11:38:58', 'active'),
(5, '20x30 Gold Medal', 2, 300, 10, 270, 115, 30, '2014-08-14 11:39:48', '2014-08-14 11:39:48', 'active'),
(6, '20x40 PP', 2, 150, 10, 125, 1005, 30, '2014-08-14 11:40:27', '2014-08-14 11:40:27', 'active'),
(7, '25x50 .03', 2, 350, 10, 300, 210, 50, '2014-08-14 11:41:58', '2014-08-14 11:41:58', 'active'),
(8, '3rd Class', 1, 2000, 7, 1700, 20, 10, '2014-08-14 11:42:25', '2014-08-14 11:42:25', 'active'),
(9, '3rd Class', 1, 40, 1, 30, 125, 50, '2014-08-14 11:42:52', '2014-08-14 11:42:52', 'active'),
(10, 'Cup 7 oz.', 5, 5, 11, 3, 1050, 120, '2014-08-14 11:43:39', '2014-08-14 11:43:39', 'active'),
(11, 'Angel Wh Flour', 1, 1900, 7, 1900, 1080, 20, '2014-08-14 11:44:16', '2014-08-14 11:44:16', 'active'),
(12, 'Angel Yeast', 23, 30, 11, 25, 1005, 30, '2014-08-14 11:45:57', '2014-08-14 11:45:57', 'active'),
(13, 'Calumet', 6, 20, 3, 15, 120, 50, '2014-08-14 11:48:06', '2014-08-14 11:48:06', 'active'),
(14, 'Cake Flour', 1, 3000, 1, 2800, 150, 100, '2014-08-14 11:49:03', '2014-08-14 11:49:03', 'active'),
(15, 'Cake Wash', 3, 50, 1, 40, 1024, 30, '2014-08-14 11:50:47', '2014-08-14 11:50:47', 'active'),
(16, 'Coco Dry', 8, 50, 1, 40, 130, 50, '2014-08-14 11:51:10', '2014-08-14 11:51:10', 'active'),
(17, 'Cowbell', 9, 500, 10, 400, 1030, 50, '2014-08-14 11:51:53', '2014-08-14 11:51:53', 'active'),
(18, 'Dobrim', 10, 500, 1, 400, 1092, 30, '2014-08-14 11:52:30', '2014-08-14 11:52:30', 'active'),
(19, 'Eden', 11, 60, 10, 40, 306, 10, '2014-08-14 11:53:23', '2014-08-14 11:53:23', 'active'),
(20, 'Farm Land', 12, 30, 3, 25, 1000, 30, '2014-08-14 11:54:37', '2014-08-14 11:54:37', 'active'),
(21, 'Flavocol-Choco', 13, 60, 11, 50, 1010, 10, '2014-08-14 11:55:27', '2014-08-14 11:55:27', 'active'),
(22, 'Flavocol-Ube', 13, 60, 11, 50, 1006, 30, '2014-08-14 11:56:13', '2014-08-14 11:56:13', 'active'),
(23, 'Flavocol-Pandan', 13, 60, 11, 50, 120, 30, '2014-08-14 11:57:08', '2014-08-14 11:57:08', 'active'),
(24, 'G. Leaves (Brown Liquid)', 13, 100, 11, 90, 1121, 50, '2014-08-14 11:58:09', '2014-08-14 11:58:09', 'active'),
(25, 'Globe', 1, 50, 1, 40, 1010, 30, '2014-08-14 11:58:25', '2014-08-14 11:58:25', 'active'),
(26, 'Milk Boy', 18, 60, 3, 50, 95, 60, '2014-08-14 11:59:10', '2014-08-14 11:59:10', 'active'),
(27, 'Palm', 19, 130, 8, 120, 1010, 30, '2014-08-14 12:00:05', '2014-08-14 12:00:05', 'active'),
(28, 'Spring Lard', 20, 200, 8, 180, 1010, 30, '2014-08-14 12:00:41', '2014-08-14 12:00:41', 'active'),
(29, 'Star Margarine', 21, 6, 4, 4, 1100, 100, '2014-08-14 12:01:12', '2014-08-14 12:01:12', 'active'),
(30, 'Sweet Crystal', 3, 50, 1, 40, 1100, 55, '2014-08-14 12:01:39', '2014-08-14 12:01:39', 'active'),
(31, 'saf', 23, 125, 11, 50, 35, 20, '2014-09-03 14:59:25', '2014-09-03 14:59:25', 'active');

-- --------------------------------------------------------

--
-- Table structure for table `purchaseorder`
--

CREATE TABLE IF NOT EXISTS `purchaseorder` (
  `poId` int(11) NOT NULL AUTO_INCREMENT,
  `supplierId` int(11) NOT NULL,
  `productId` int(11) NOT NULL,
  `status` varchar(15) NOT NULL,
  `dateArrival` datetime NOT NULL,
  `qty` int(11) NOT NULL,
  PRIMARY KEY (`poId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE IF NOT EXISTS `supplier` (
  `supplierId` int(11) NOT NULL AUTO_INCREMENT,
  `supplierName` varchar(50) NOT NULL,
  `supplierContact` varchar(20) NOT NULL,
  `supplierContactPerson` varchar(120) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(10) NOT NULL,
  `supplierAddress` varchar(200) NOT NULL,
  PRIMARY KEY (`supplierId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`supplierId`, `supplierName`, `supplierContact`, `supplierContactPerson`, `created_date`, `updated_date`, `status`, `supplierAddress`) VALUES
(1, 'Randerson Marketing', '22222', 'Racquel', '2014-08-14 13:34:43', '2014-08-14 13:34:43', 'active', 'TARLAC CITY'),
(2, 'JRP Trading', 'Pangasinan', '', '2014-08-14 13:35:09', '2014-08-14 13:35:09', 'active', ''),
(3, 'test', 'test', 'test', '2014-08-16 02:50:32', '2014-08-16 02:50:32', 'active', 'test');

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE IF NOT EXISTS `transaction` (
  `transId` int(11) NOT NULL AUTO_INCREMENT,
  `orNo` int(11) NOT NULL,
  `productId` varchar(50) NOT NULL,
  `clientId` int(11) NOT NULL,
  `paymentMethod` varchar(15) NOT NULL,
  `transDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `transStatus` varchar(10) NOT NULL,
  `qty` int(11) NOT NULL,
  `unitId` int(11) NOT NULL,
  `supplierPrice` double NOT NULL,
  `unitPrice` double NOT NULL,
  `paidBalance` double NOT NULL,
  `yellowBasyoReturned` int(11) NOT NULL,
  `transparentBasyoReturned` int(11) NOT NULL,
  PRIMARY KEY (`transId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=31 ;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`transId`, `orNo`, `productId`, `clientId`, `paymentMethod`, `transDate`, `transStatus`, `qty`, `unitId`, `supplierPrice`, `unitPrice`, `paidBalance`, `yellowBasyoReturned`, `transparentBasyoReturned`) VALUES
(19, 2014100012, '19', 2, 'Balance', '2014-09-23 23:09:43', 'Completed', 10, 10, 40, 60, 230, 0, 0),
(20, 2014100013, '19', 2, 'Cash', '2014-09-23 23:10:45', 'Completed', 1, 10, 1900, 1900, 0, 0, 0),
(21, 2014100013, '18', 2, 'Cash', '2014-09-23 23:10:46', 'Completed', 1, 1, 1900, 1900, 0, 0, 0),
(22, 2014100013, '11', 2, 'Cash', '2014-09-23 23:10:46', 'Completed', 2, 7, 1900, 1900, 0, 0, 0),
(23, 2014100014, '19', 2, 'Cash', '2014-09-23 23:11:53', 'Completed', 1, 10, 40, 60, 0, 0, 0),
(24, 2014100014, '18', 2, 'Cash', '2014-09-23 23:11:53', 'Completed', 2, 1, 400, 500, 0, 0, 0),
(25, 2014100014, '14', 2, 'Cash', '2014-09-23 23:11:54', 'Completed', 3, 1, 2800, 3000, 0, 0, 0),
(26, 2014100015, '26', 1, 'Balance', '2014-09-24 14:48:57', 'Completed', 10, 3, 50, 60, 600, 0, 0),
(27, 2014110016, '19', 1, 'Cheque', '2014-10-04 22:30:59', 'Completed', 10, 10, 40, 60, 0, 0, 0),
(28, 2014110017, '19', 2, 'Cheque', '2014-10-04 23:01:42', 'Completed', 20, 10, 40, 60, 0, 0, 0),
(29, 2014110018, '19', 4, 'Balance', '2014-10-04 23:02:02', 'Completed', 5, 10, 40, 60, 230, 0, 0),
(30, 2014110019, '27', 1, 'Cash', '2014-10-08 22:39:00', 'Completed', 10, 8, 120, 130, 0, 0, 10);

-- --------------------------------------------------------

--
-- Table structure for table `units`
--

CREATE TABLE IF NOT EXISTS `units` (
  `unitId` int(11) NOT NULL AUTO_INCREMENT,
  `unitDesc` varchar(65) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`unitId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `units`
--

INSERT INTO `units` (`unitId`, `unitDesc`, `created_date`, `updated_date`, `status`) VALUES
(1, 'Kg', '2014-08-14 11:28:03', '2014-08-14 11:28:03', 'active'),
(2, '1/2 kg', '2014-08-14 11:28:10', '2014-08-14 11:28:10', 'active'),
(3, '1/4 kg', '2014-08-14 11:28:14', '2014-08-14 11:28:14', 'active'),
(4, '100 grams', '2014-08-14 11:28:29', '2014-08-14 11:28:29', 'active'),
(5, 'Large', '2014-08-14 11:28:44', '2014-08-14 11:28:44', 'active'),
(6, 'Medium', '2014-08-14 11:28:46', '2014-08-14 11:28:46', 'active'),
(7, 'Sack', '2014-08-14 11:28:54', '2014-08-14 11:28:54', 'active'),
(8, 'Liter', '2014-08-14 11:29:03', '2014-08-14 11:29:03', 'active'),
(9, 'Tiny', '2014-08-14 11:30:24', '2014-08-14 11:30:24', 'active'),
(10, 'Box', '2014-08-14 11:30:45', '2014-08-14 11:30:45', 'active'),
(11, 'Piece', '2014-08-14 11:35:40', '2014-08-14 11:35:40', 'active');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `userId` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(65) NOT NULL,
  `password` varchar(150) NOT NULL,
  `fullname` varchar(200) NOT NULL,
  `permissionId` int(11) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userId`, `username`, `password`, `fullname`, `permissionId`, `created_date`, `updated_date`, `status`) VALUES
(1, 'test', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08', 'test', 1, '2014-08-29 00:37:49', '2014-08-29 00:37:49', 'active'),
(2, 'carol', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'caroline chiu', 1, '2014-09-03 14:50:24', '2014-09-03 14:50:24', 'active');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
