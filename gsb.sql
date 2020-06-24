
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `gsb`
--

-- --------------------------------------------------------

--
-- Structure de la table `comptabilite`
--

DROP TABLE IF EXISTS `comptabilite`;
CREATE TABLE IF NOT EXISTS `comptabilite` (
  `COMPTAMatricule` int(11) NOT NULL AUTO_INCREMENT,
  `COMPTANom` varchar(255) NOT NULL,
  `COMPTAPrenom` varchar(255) NOT NULL,
  `COMPTAEmail` varchar(255) NOT NULL,
  `COMPTAMdp` varchar(255) NOT NULL,
  PRIMARY KEY (`COMPTAMatricule`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `demanderemboursement`
--

DROP TABLE IF EXISTS `demanderemboursement`;
CREATE TABLE IF NOT EXISTS `demanderemboursement` (
  `DEMANDECode` int(11) NOT NULL AUTO_INCREMENT,
  `DEMANDEDate` date NOT NULL,
  `DEMANDENbrJustificatif` int(11) NOT NULL,
  `ETATDEMANDECode` varchar(10) NOT NULL,
  `VISITEURMatricule` int(11) NOT NULL,
  PRIMARY KEY (`DEMANDECode`),
  KEY `fk_visiteur` (`VISITEURMatricule`),
  KEY `fk_demandeetat` (`ETATDEMANDECode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `etatdemande`
--

DROP TABLE IF EXISTS `etatdemande`;
CREATE TABLE IF NOT EXISTS `etatdemande` (
  `ETATDEMANDECode` varchar(10) NOT NULL,
  `ETATDEMANDELibelle` varchar(100) NOT NULL,
  PRIMARY KEY (`ETATDEMANDECode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `fraisforfaitaire`
--

DROP TABLE IF EXISTS `fraisforfaitaire`;
CREATE TABLE IF NOT EXISTS `fraisforfaitaire` (
  `FRAISFORFAITAIRECode` int(11) NOT NULL AUTO_INCREMENT,
  `FRAISFORFAITAIRELibelle` varchar(255) NOT NULL,
  `FRAISFORFAITAIREMontant` double NOT NULL,
  PRIMARY KEY (`FRAISFORFAITAIRECode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `lignefraisforfaitaire`
--

DROP TABLE IF EXISTS `lignefraisforfaitaire`;
CREATE TABLE IF NOT EXISTS `lignefraisforfaitaire` (
  `DEMANDECode` int(11) NOT NULL,
  `FRAISFORFAITAIRECode` int(11) NOT NULL,
  `LIGNEFFAccepte` tinyint(1) NOT NULL,
  `LIGNEFFQuantite` int(11) NOT NULL,
  PRIMARY KEY (`DEMANDECode`,`FRAISFORFAITAIRECode`),
  KEY `fk_frais` (`FRAISFORFAITAIRECode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `lignefraishorsforfait`
--

DROP TABLE IF EXISTS `lignefraishorsforfait`;
CREATE TABLE IF NOT EXISTS `lignefraishorsforfait` (
  `LIGNEHFNum` int(11) NOT NULL AUTO_INCREMENT,
  `LIGNEHFLibelle` varchar(255) NOT NULL,
  `LIGNEHFMontant` double NOT NULL,
  `LIGNEHFDate` date NOT NULL,
  `LIGNEHFAccepte` tinyint(1) NOT NULL,
  `DEMANDECode` int(11) NOT NULL,
  PRIMARY KEY (`LIGNEHFNum`),
  KEY `fk_demandecode` (`DEMANDECode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `visiteur`
--

DROP TABLE IF EXISTS `visiteur`;
CREATE TABLE IF NOT EXISTS `visiteur` (
  `VISITEURMatricule` int(11) NOT NULL AUTO_INCREMENT,
  `VISITEURNom` varchar(255) NOT NULL,
  `VISITEURPrenom` varchar(255) NOT NULL,
  `VISITEURAdresse` varchar(255) NOT NULL,
  `VISITEURCp` varchar(10) NOT NULL,
  `VISITEURVille` varchar(255) NOT NULL,
  `VISITEURDateEmbauche` date NOT NULL,
  `VISITEUREmail` varchar(255) NOT NULL,
  `VISITEURMdp` varchar(255) NOT NULL,
  PRIMARY KEY (`VISITEURMatricule`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `demanderemboursement`
--
ALTER TABLE `demanderemboursement`
  ADD CONSTRAINT `fk_demandeetat` FOREIGN KEY (`ETATDEMANDECode`) REFERENCES `etatdemande` (`ETATDEMANDECode`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `fk_visiteur` FOREIGN KEY (`VISITEURMatricule`) REFERENCES `visiteur` (`VISITEURMatricule`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Contraintes pour la table `lignefraisforfaitaire`
--
ALTER TABLE `lignefraisforfaitaire`
  ADD CONSTRAINT `fk_demande` FOREIGN KEY (`DEMANDECode`) REFERENCES `demanderemboursement` (`DEMANDECode`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `fk_frais` FOREIGN KEY (`FRAISFORFAITAIRECode`) REFERENCES `fraisforfaitaire` (`FRAISFORFAITAIRECode`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Contraintes pour la table `lignefraishorsforfait`
--
ALTER TABLE `lignefraishorsforfait`
  ADD CONSTRAINT `fk_demandecode` FOREIGN KEY (`DEMANDECode`) REFERENCES `demanderemboursement` (`DEMANDECode`) ON DELETE RESTRICT ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
