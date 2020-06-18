-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-03-2020 a las 18:15:34
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `reserva_aulas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aulas`
--

CREATE TABLE `aulas` (
  `Nombre` varchar(8) COLLATE latin1_spanish_ci NOT NULL,
  `Descripcion` varchar(150) COLLATE latin1_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `disponibilidades`
--

CREATE TABLE `disponibilidades` (
  `IdDisp` int(2) NOT NULL,
  `Aula` varchar(8) COLLATE latin1_spanish_ci NOT NULL,
  `IdFranja` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `franjas`
--

CREATE TABLE `franjas` (
  `FranjaId` int(10) NOT NULL,
  `DiaSemana` varchar(10) COLLATE latin1_spanish_ci NOT NULL,
  `FranjaHoraria` varchar(15) COLLATE latin1_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reservas`
--

CREATE TABLE `reservas` (
  `Aula` varchar(8) COLLATE latin1_spanish_ci NOT NULL,
  `Fecha` date NOT NULL,
  `Franja` int(10) NOT NULL,
  `User` varchar(8) COLLATE latin1_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE `users` (
  `UserName` varchar(8) COLLATE latin1_spanish_ci NOT NULL,
  `Password` varchar(8) COLLATE latin1_spanish_ci NOT NULL,
  `Rol` varchar(8) COLLATE latin1_spanish_ci NOT NULL,
  `Email` varchar(20) COLLATE latin1_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `aulas`
--
ALTER TABLE `aulas`
  ADD PRIMARY KEY (`Nombre`);

--
-- Indices de la tabla `disponibilidades`
--
ALTER TABLE `disponibilidades`
  ADD PRIMARY KEY (`IdDisp`),
  ADD KEY `AulaFK` (`Aula`),
  ADD KEY `FranjaFK` (`IdFranja`);

--
-- Indices de la tabla `franjas`
--
ALTER TABLE `franjas`
  ADD PRIMARY KEY (`FranjaId`);

--
-- Indices de la tabla `reservas`
--
ALTER TABLE `reservas`
  ADD PRIMARY KEY (`Aula`,`Fecha`,`Franja`),
  ADD KEY `FranjaReservaFK` (`Franja`),
  ADD KEY `UserReservaFK` (`User`);

--
-- Indices de la tabla `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserName`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `disponibilidades`
--
ALTER TABLE `disponibilidades`
  MODIFY `IdDisp` int(2) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `franjas`
--
ALTER TABLE `franjas`
  MODIFY `FranjaId` int(10) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `disponibilidades`
--
ALTER TABLE `disponibilidades`
  ADD CONSTRAINT `AulaFK` FOREIGN KEY (`Aula`) REFERENCES `aulas` (`Nombre`),
  ADD CONSTRAINT `FranjaFK` FOREIGN KEY (`IdFranja`) REFERENCES `franjas` (`FranjaId`);

--
-- Filtros para la tabla `reservas`
--
ALTER TABLE `reservas`
  ADD CONSTRAINT `AulaReservaFK` FOREIGN KEY (`Aula`) REFERENCES `aulas` (`Nombre`),
  ADD CONSTRAINT `FranjaReservaFK` FOREIGN KEY (`Franja`) REFERENCES `franjas` (`FranjaId`),
  ADD CONSTRAINT `UserReservaFK` FOREIGN KEY (`User`) REFERENCES `users` (`UserName`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
