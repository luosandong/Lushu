/*
Navicat MySQL Data Transfer

Source Server         : Local_Lushu
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : lushu

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2019-09-07 17:48:05
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for book_category
-- ----------------------------
DROP TABLE IF EXISTS `book_category`;
CREATE TABLE `book_category` (
  `id` varchar(50) NOT NULL DEFAULT '' COMMENT '主键',
  `name` varchar(20) NOT NULL,
  `parent_id` varchar(50) DEFAULT NULL,
  `sequence` int(4) DEFAULT NULL,
  `layer` int(4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_index` (`id`) USING HASH
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
