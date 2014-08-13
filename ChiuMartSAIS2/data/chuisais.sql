-- phpMyAdmin SQL Dump
-- version 4.1.12
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Aug 13, 2014 at 08:49 AM
-- Server version: 5.6.16
-- PHP Version: 5.5.11

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
-- Table structure for table `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `categoryId` int(11) NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(65) NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`categoryId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`categoryId`, `categoryName`, `created_date`, `updated_date`, `status`) VALUES
(1, 'Rice', '2014-08-13 14:42:36', '2014-08-13 14:43:27', ''),
(2, 'Sugar', '2014-08-13 14:42:36', '2014-08-13 14:43:27', ''),
(4, 'Vinegar', '2014-08-13 14:42:36', '2014-08-13 14:43:27', ''),
(5, 'test', '2014-08-13 14:42:36', '2014-08-13 14:43:27', ''),
(6, 'test2', '2014-08-13 14:42:36', '2014-08-13 14:43:27', ''),
(7, 'test3', '2014-08-13 14:42:36', '2014-08-13 14:43:27', ''),
(8, 'test4', '2014-08-13 14:42:36', '2014-08-13 14:43:27', '');

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
  PRIMARY KEY (`clientId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`clientId`, `clientName`, `clientContact`, `created_date`, `updated_date`, `status`) VALUES
(2, 'testin', '', '2014-08-13 14:45:01', '2014-08-13 14:45:01', '');

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
  `productStock` int(11) NOT NULL,
  `productSafetyStock` int(11) NOT NULL,
  `created_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`productId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`productId`, `productName`, `categoryId`, `productPrice`, `unitId`, `productStock`, `productSafetyStock`, `created_time`, `updated_time`, `status`) VALUES
(1, 'sugar free', 2, 10.5, 2, 101, 11, '2014-08-13 14:46:13', '2014-08-13 14:46:13', ''),
(2, 'test', 4, 11, 1, 11, 11, '2014-08-13 14:46:13', '2014-08-13 14:46:13', ''),
(3, 'Product Test', 8, 12, 1, 12, 5, '2014-08-13 14:46:13', '2014-08-13 14:46:13', ''),
(4, 'producto sugar', 2, 50, 1, 50, 12, '2014-08-13 14:46:13', '2014-08-13 14:46:13', ''),
(5, 'Bulaklak', 1, 2000, 2, 5, 30, '2014-08-13 14:46:13', '2014-08-13 14:46:13', ''),
(6, 'Candy', 2, 10, 2, 20, 100, '2014-08-13 14:46:13', '2014-08-13 14:46:13', ''),
(7, 'Test Product po to', 4, 15, 2, 20, 25, '2014-08-13 14:46:13', '2014-08-13 14:46:13', '');

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
  PRIMARY KEY (`supplierId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`supplierId`, `supplierName`, `supplierContact`, `supplierContactPerson`, `created_date`, `updated_date`, `status`) VALUES
(1, 'testing', 'test', '', '2014-08-13 14:47:56', '2014-08-13 14:47:56', '');

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
  `transDate` datetime NOT NULL,
  `transStatus` varchar(10) NOT NULL,
  PRIMARY KEY (`transId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `units`
--

INSERT INTO `units` (`unitId`, `unitDesc`, `created_date`, `updated_date`, `status`) VALUES
(1, '1 kg', '2014-08-13 14:49:15', '2014-08-13 14:49:15', ''),
(2, '250 grams', '2014-08-13 14:49:15', '2014-08-13 14:49:15', '');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
