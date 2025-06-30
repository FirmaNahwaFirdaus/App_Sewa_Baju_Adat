-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 30, 2025 at 05:03 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sewa_baju_adat`
--

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id`, `username`, `password`) VALUES
(1, 'koko', 'kasir1');

-- --------------------------------------------------------

--
-- Table structure for table `sewa`
--

CREATE TABLE `sewa` (
  `id` int(10) NOT NULL,
  `nama_penyewa` text NOT NULL,
  `baju_adat` text NOT NULL,
  `ukuran` text NOT NULL,
  `tanggal_sewa` date NOT NULL,
  `jumlah_barang` int(10) NOT NULL,
  `jumlah_hari` int(5) NOT NULL,
  `pengiriman` text NOT NULL,
  `alamat` text NOT NULL,
  `metode_bayar` text NOT NULL,
  `total_harga` int(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sewa`
--

INSERT INTO `sewa` (`id`, `nama_penyewa`, `baju_adat`, `ukuran`, `tanggal_sewa`, `jumlah_barang`, `jumlah_hari`, `pengiriman`, `alamat`, `metode_bayar`, `total_harga`) VALUES
(4, 'kue', 'Baju Lurik', 'S', '2025-03-31', 2, 2, 'Ambil', 'nganjuk', 'cash', 140000),
(7, 'roki', 'Jarik', 'M', '2025-04-20', 2, 1, 'Ambil', 'sini', 'cash', 60000),
(8, 'emaa', 'Baju Lurik', 'XL', '2025-04-20', 1, 2, 'Ambil', 'kepung', 'transfer', 70000),
(9, 'juliat', 'Kebaya Sunda', 'L', '2025-05-07', 2, 1, 'Ambil', 'kediri', 'transfer', 100000),
(12, 'romli', 'Baju Lurik', 'XL', '2025-05-08', 1, 2, 'Ambil', 'ngasem', 'cash', 70000),
(16, 'jasmine', 'Kebaya Sunda', 'L', '2025-05-08', 2, 1, 'Ambil', 'pagu', 'transfer', 100000),
(17, 'suki', 'Blangkon', 'M', '2025-05-08', 5, 2, 'Ambil', 'papar', 'transfer', 100000),
(18, 'kenan', 'Baju Lurik', 'S', '2025-05-08', 2, 3, 'Antar', 'kandat', 'transfer', 212000),
(19, 'reza', 'Blangkon', 'M', '2025-05-08', 10, 2, 'Ambil', 'nganjuk', 'cash', 200000),
(21, 'Zefa', 'Jarik', 'M', '2025-05-11', 3, 2, 'Ambil', 'kerto', 'transfer', 180000),
(22, 'okin', 'Baju Bodo', 'XL', '2025-05-14', 1, 2, 'Ambil', '', 'transfer', 120000),
(23, 'revi', 'Baju Lurik', 'L', '2025-05-13', 2, 2, 'Antar', '', 'transfer', 142000),
(24, 'rangga', 'Blangkon', 'L', '2025-05-13', 5, 2, 'Ambil', 'papar', 'cash', 100000),
(25, 'aksel', 'Baju Lurik', 'M', '2025-05-13', 3, 2, 'Ambil', 'plemahan', 'transfer', 210000),
(26, 'egi', 'Kebaya Sunda', 'L', '2025-05-24', 2, 3, 'Ambil', 'gurah', 'transfer', 300000),
(27, 'elma', 'Kebaya Bali', 'L', '2025-05-25', 2, 1, 'Antar', 'tepus', 'transfer', 112000),
(28, 'zico', 'Baju Lurik', 'L', '2025-05-25', 2, 1, 'Ambil', 'ngasem', 'cash', 70000),
(29, 'komo', 'Baju Lurik', 'XXL', '2025-05-27', 2, 1, 'Ambil', 'nganjuk', 'cash', 70000),
(30, 'uki', 'Baju Lurik', 'L', '2025-05-27', 3, 1, 'Ambil', 'kediri', 'cash', 105000),
(31, 'koko', 'Baju Bodo', 'L', '2025-05-27', 3, 2, 'Ambil', 'kediri', 'cash', 390000),
(32, 'eko', 'Kebaya Bali', 'L', '2025-06-29', 2, 1, 'Ambil', 'kediri', 'cash', 110000),
(33, 'sasa', 'Kebaya Bali', 'M', '2025-06-29', 3, 1, 'Ambil', 'kediri', 'transfer', 165000),
(34, 'erni', 'Kebaya Sunda', 'M', '2025-06-29', 5, 2, 'Antar', 'kediri', 'transfer', 502000);

-- --------------------------------------------------------

--
-- Table structure for table `stok`
--

CREATE TABLE `stok` (
  `id` int(5) NOT NULL,
  `baju_adat` text NOT NULL,
  `ukuran` text NOT NULL,
  `stok_total` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `stok`
--

INSERT INTO `stok` (`id`, `baju_adat`, `ukuran`, `stok_total`) VALUES
(1, 'Kebaya', 'S', 5),
(2, 'Kebaya', 'M', 5),
(3, 'Kebaya', 'L', 5),
(4, 'Kebaya', 'XL', 5),
(5, 'Kebaya Sunda', 'S', 5),
(6, 'Kebaya Sunda', 'M', 5),
(7, 'Kebaya Sunda', 'L', 5),
(8, 'Kebaya Sunda', 'XL', 5),
(9, 'Kebaya Bali', 'S', 5),
(10, 'Kebaya Bali', 'M', 5),
(11, 'Kebaya Bali', 'L', 5),
(12, 'Kebaya Bali', 'XL', 5),
(13, 'Baju Bodo', 'S', 5),
(14, 'Baju Bodo', 'M', 5),
(15, 'Baju Bodo', 'L', 5),
(16, 'Baju Bodo', 'XL', 5),
(17, 'Baju Lurik', 'S', 5),
(18, 'Baju Lurik', 'M', 5),
(19, 'Baju Lurik', 'L', 5),
(20, 'Baju Lurik', 'XL', 5),
(21, 'Jarik', 'S', 5),
(22, 'Jarik', 'M', 5),
(23, 'Jarik', 'L', 5),
(24, 'Jarik', 'XL', 5),
(25, 'Blangkon', 'S', 5),
(26, 'Blangkon', 'M', 5),
(27, 'Blangkon', 'L', 5),
(28, 'Blangkon', 'XL', 5),
(29, 'Udeng', 'S', 5),
(30, 'Udeng', 'M', 5),
(31, 'Udeng', 'L', 5),
(32, 'Udeng', 'XL', 5);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sewa`
--
ALTER TABLE `sewa`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stok`
--
ALTER TABLE `stok`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `sewa`
--
ALTER TABLE `sewa`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `stok`
--
ALTER TABLE `stok`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
