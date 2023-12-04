-- Active: 1701191025551@@SG-midi-taurus-4990-7989-mysql-master.servers.mongodirector.com@3306@The-Neon-Tsunami
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS cults (
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1500) NOT NULL,
  coverImg VARCHAR(1000) NOT NULL,
  fee DOUBLE DEFAULT 0,
  invitationRequired BOOLEAN DEFAULT false,
  memberCount INT DEFAULT 0,
  leaderId VARCHAR(255) NOT NULL,
  Foreign Key (leaderId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8;

DROP TABLE cults

INSERT INTO cults
(name, description, coverImg, fee, invitationRequired, leaderId )
VALUES
("Arby's Lovers", "In Verdant Grove, the 'Arby's Lovers' cult, led by the charismatic Cyrus Munchmore, worships the now-defunct fast-food giant. Clad in burgundy and beige robes adorned with roast beef motifs, members gather secretly for rituals chanting Arby's slogans and meditating on the spiritual power of curly fries. The belief centers on consuming Arby's offerings to attain a higher plane, connecting with a divine roast beef energy. Despite skepticism from the community about mind-altering condiments, the cult's online presence grows, attracting curious souls to their unconventional practices. The town remains divided, unsure if the Arby's Lovers are a harmless subculture or harbor a darker agenda.", "https://nmgprod.s3.amazonaws.com/media/files/1d/51/1d51b65adc598f30106c528add436e36/cover_image_1674480489.jpg.760x400_q85_crop_upscale.jpg", 7.99, false, '656e029147ce3892a40d678b')

CREATE TABLE IF NOT EXISTS cultMembers(
  id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  accountId VARCHAR(255) NOT NULL,
  cultId INT NOT NULL,
  Foreign Key (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  Foreign Key (cultId) REFERENCES cults(id) ON DELETE CASCADE,
  UNIQUE(accountId, cultId)
) default charset utf8;

DROP TABLE `cultMembers`

INSERT INTO cultMembers
(`accountId`, `cultId`)
VALUES
('656e04ecd3062903aa3d0a8d', 1)