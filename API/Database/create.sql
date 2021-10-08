-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 08, 2021 at 12:12 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.11
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */
;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */
;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */
;
/*!40101 SET NAMES utf8mb4 */
;
--
use `luckyfightcs_database` --
-- --------------------------------------------------------
--
-- Table structure for table `heroes`
--
CREATE TABLE `Heroes` (
    `Id` int(11) NOT NULL,
    `Name` longtext DEFAULT NULL,
    `UserId` int(11) DEFAULT NULL,
    `Icon` longtext DEFAULT NULL,
    `Pv` int(11) NOT NULL,
    `Atk` int(11) NOT NULL,
    `IsSwag` tinyint(1) NOT NULL,
    `NbFights` int(11) NOT NULL,
    `IsChampion` tinyint(1) NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4;
--
-- Dumping data for table `heroes`
--
INSERT INTO `Heroes` (
        `Id`,
        `Name`,
        `UserId`,
        `Icon`,
        `Pv`,
        `Atk`,
        `IsSwag`,
        `NbFights`,
        `IsChampion`
    )
VALUES (1, 'mara', 1, 'logo', 10, 1, 1, 3, 1),
    (2, 'amaury', 1, 'logo', 10, 1, 1, 3, 0),
    (3, 'Yassine', 2, 'logo', 1, 1, 1, 0, 0),
    (4, 'Allan', 2, 'logo', 1, 1, 0, 0, 0),
    (6, 'new', 1, 'icon', 22, 1, 0, 0, 0),
    (7, 'test', 1, 'icon', 24, 1, 0, 0, 0);
-- --------------------------------------------------------
--
-- Table structure for table `users`
--
CREATE TABLE `Users` (
    `Id` int(11) NOT NULL,
    `Email` longtext DEFAULT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4;
--
-- Dumping data for table `users`
--
INSERT INTO `Users` (`Id`, `Email`)
VALUES (1, 'cc'),
    (2, 'amaury');
-- --------------------------------------------------------
--
-- Table structure for table `__efmigrationshistory`
--
CREATE TABLE `__efmigrationshistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4;
--
-- Dumping data for table `__efmigrationshistory`
--
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`)
VALUES ('20211007094120_InitialCreate', '5.0.10'),
    ('20211007144824_FixAutoIncrement', '5.0.10'),
    ('20211007145015_FixAutoIncrement2', '5.0.10'),
    ('20211008061935_AddEmailToUser', '5.0.10');
--
-- Indexes for dumped tables
--
--
-- Indexes for table `heroes`
--
ALTER TABLE `Heroes`
ADD PRIMARY KEY (`Id`),
    ADD KEY `IX_Heroes_UserId` (`UserId`);
--
-- Indexes for table `users`
--
ALTER TABLE `Users`
ADD PRIMARY KEY (`Id`);
--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
ADD PRIMARY KEY (`MigrationId`);
--
-- AUTO_INCREMENT for dumped tables
--
--
-- AUTO_INCREMENT for table `heroes`
--
ALTER TABLE `Heroes`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,
    AUTO_INCREMENT = 8;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `Users`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,
    AUTO_INCREMENT = 3;
--
-- Constraints for dumped tables
--
--
-- Constraints for table `heroes`
--
ALTER TABLE `Heroes`
ADD CONSTRAINT `FK_Heroes_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`);
COMMIT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */
;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */
;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */
;