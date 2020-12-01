/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : PostgreSQL
 Source Server Version : 110002
 Source Host           : localhost:5432
 Source Catalog        : APL_DEV2
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 110002
 File Encoding         : 65001

 Date: 30/11/2020 17:54:43
*/




-- ----------------------------
-- Sequence structure for attachment_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."attachment_id_seq";
CREATE SEQUENCE "public"."attachment_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;


-- ----------------------------
-- Sequence structure for material_brand_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."material_brand_id_seq";
CREATE SEQUENCE "public"."material_brand_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for material_category_config_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."material_category_config_id_seq";
CREATE SEQUENCE "public"."material_category_config_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for material_category_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."material_category_id_seq";
CREATE SEQUENCE "public"."material_category_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for material_config_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."material_config_id_seq";
CREATE SEQUENCE "public"."material_config_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for material_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."material_id_seq";
CREATE SEQUENCE "public"."material_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for material_serial_no_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."material_serial_no_id_seq";
CREATE SEQUENCE "public"."material_serial_no_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for material_type_config_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."material_type_config_id_seq";
CREATE SEQUENCE "public"."material_type_config_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for material_type_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."material_type_id_seq";
CREATE SEQUENCE "public"."material_type_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for sys_lookup_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."sys_lookup_id_seq";
CREATE SEQUENCE "public"."sys_lookup_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;


-- ----------------------------
-- Sequence structure for sys_role_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."sys_role_id_seq";
CREATE SEQUENCE "public"."sys_role_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for sys_user_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."sys_user_id_seq";
CREATE SEQUENCE "public"."sys_user_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Table structure for attachment
-- ----------------------------
DROP TABLE IF EXISTS "public"."attachment";
CREATE TABLE "public"."attachment" (
  "id" int4 NOT NULL DEFAULT nextval('attachment_id_seq'::regclass),
  "create_time" timestamp(6),
  "create_user_id" int4,
  "create_user_name" text COLLATE "pg_catalog"."default",
  "modify_time" timestamp(6),
  "modify_user_id" int4,
  "modify_user_name" text COLLATE "pg_catalog"."default",
  "main_id" int4,
  "file_name" text COLLATE "pg_catalog"."default",
  "orginal_file_name" text COLLATE "pg_catalog"."default",
  "type" text COLLATE "pg_catalog"."default",
  "content_type" text COLLATE "pg_catalog"."default",
  "file_extention" text COLLATE "pg_catalog"."default",
  "size" int8,
  "md5" text COLLATE "pg_catalog"."default",
  "sha" text COLLATE "pg_catalog"."default",
  "version" text COLLATE "pg_catalog"."default",
  "download_times" int4,
  "file_guid" text COLLATE "pg_catalog"."default"
)
;



-- ----------------------------
-- Table structure for material
-- ----------------------------
DROP TABLE IF EXISTS "public"."material";
CREATE TABLE "public"."material" (
  "id" int4 NOT NULL DEFAULT nextval('material_id_seq'::regclass),
  "create_time" timestamp(6),
  "create_user_id" int4,
  "create_user_name" text COLLATE "pg_catalog"."default",
  "modify_time" timestamp(6),
  "modify_user_id" int4,
  "modify_user_name" text COLLATE "pg_catalog"."default",
  "status" int4,
  "name" text COLLATE "pg_catalog"."default",
  "short_name" text COLLATE "pg_catalog"."default",
  "category_id" int4,
  "category_code" text COLLATE "pg_catalog"."default",
  "type_id" int4,
  "type_name" text COLLATE "pg_catalog"."default",
  "brand_id" int4,
  "brand_name" text COLLATE "pg_catalog"."default",
  "desc" text COLLATE "pg_catalog"."default",
  "part_number" text COLLATE "pg_catalog"."default",
  "detail" text COLLATE "pg_catalog"."default",
  "container_material_id" int4,
  "container_part_number" text COLLATE "pg_catalog"."default",
  "rack_id" int4,
  "rack_pn" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of material
-- ----------------------------
INSERT INTO "public"."material" VALUES (24, '2019-07-06 21:51:19.792094', NULL, 'admin', '2019-07-06 21:51:19.792095', NULL, 'admin', NULL, '末端修复mix', NULL, 5, 'Reagent', 12, '混合液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGMX01', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (25, '2019-07-06 21:51:41.816627', NULL, 'admin', '2019-07-06 21:51:41.816628', NULL, 'admin', NULL, '2X单链环化makeDNB试剂板', NULL, 5, 'Reagent', 12, '混合液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGMX02', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (26, '2019-07-06 21:51:53.919667', NULL, 'admin', '2019-07-06 21:51:53.919667', NULL, 'admin', NULL, '5X单链环化makeDNB试剂板', NULL, 5, 'Reagent', 12, '混合液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGMX03', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (27, '2019-07-06 21:52:15.399986', NULL, 'admin', '2019-07-06 21:52:15.399986', NULL, 'admin', NULL, '8X单链环化makeDNB试剂板', NULL, 5, 'Reagent', 12, '混合液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGMX04', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (28, '2019-07-06 21:52:32.456794', NULL, 'admin', '2019-07-06 21:52:32.456794', NULL, 'admin', NULL, '末端修复缓冲液', NULL, 5, 'Reagent', 7, '缓冲液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBF01', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (29, '2019-07-06 21:52:46.48943', NULL, 'admin', '2019-07-06 21:52:46.489431', NULL, 'admin', NULL, '连接反应缓冲液', NULL, 5, 'Reagent', 7, '缓冲液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBF02', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (30, '2019-07-06 21:53:00.882404', NULL, 'admin', '2019-07-06 21:53:00.882405', NULL, 'admin', NULL, 'PCR反应液', NULL, 5, 'Reagent', 7, '缓冲液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBF03', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (31, '2019-07-06 21:53:16.229488', NULL, 'admin', '2019-07-06 21:53:16.229488', NULL, 'admin', NULL, '末端修复酶', NULL, 5, 'Reagent', 11, '酶', 16, '华大生物科技/股份公司/BGI', NULL, 'BGEZ01', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (32, '2019-07-06 21:53:27.952468', NULL, 'admin', '2019-07-06 21:53:27.952468', NULL, 'admin', NULL, '连接酶', NULL, 5, 'Reagent', 11, '酶', 16, '华大生物科技/股份公司/BGI', NULL, 'BGEZ02', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (33, '2019-07-06 21:53:43.21666', NULL, 'admin', '2019-07-06 21:53:43.216661', NULL, 'admin', NULL, 'PCR引物', NULL, 5, 'Reagent', 13, '引物', 16, '华大生物科技/股份公司/BGI', NULL, 'BGPM01', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (34, '2019-07-06 21:53:56.720952', NULL, 'admin', '2019-07-06 21:53:56.720952', NULL, 'admin', NULL, '五倍稀释barcode', NULL, 5, 'Reagent', 15, '接头', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBC01', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (4, '2019-07-06 21:37:58.842061', NULL, 'admin', '2019-07-27 16:13:29.060879', NULL, 'admin', NULL, '13层堆栈料架', NULL, 1, 'Rack', 2, '料架', 1, '华大智造/MGI', '深孔板', 'MGRK03', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (5, '2019-07-06 21:38:22.995004', NULL, 'admin', '2019-08-05 16:31:59.691371', NULL, 'admin', NULL, '18层堆栈料架', NULL, 1, 'Rack', 2, '料架', 1, '华大智造/MGI', 'PCR板（基准）、酶标板', 'MGRK04', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (3, '2019-07-06 21:37:34.595329', NULL, 'admin', '2019-07-27 16:13:11.532909', NULL, 'admin', NULL, '7层堆栈料架', NULL, 1, 'Rack', 2, '料架', 1, '华大智造/MGI', '吸头', 'MGRK02', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (12, '2019-07-06 21:46:43.627229', NULL, 'admin', '2019-07-06 21:46:43.62723', NULL, 'admin', NULL, '提取磁珠+PK', NULL, 5, 'Reagent', 10, '磁珠', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBD01', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (13, '2019-07-06 21:47:24.071731', NULL, 'admin', '2019-07-06 21:47:24.071731', NULL, 'admin', NULL, '纯化磁珠(2号工位45uL)', NULL, 5, 'Reagent', 10, '磁珠', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBD02', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (14, '2019-07-06 21:47:48.7041', NULL, 'admin', '2019-07-06 21:47:48.704101', NULL, 'admin', NULL, '纯化磁珠(2号工位30uL)', NULL, 5, 'Reagent', 10, '磁珠', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBD03', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (15, '2019-07-06 21:48:12.99901', NULL, 'admin', '2019-07-06 21:48:12.999011', NULL, 'admin', NULL, '纯化磁珠(3号工位40uL)', NULL, 5, 'Reagent', 10, '磁珠', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBD04', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (16, '2019-07-06 21:48:29.264203', NULL, 'admin', '2019-07-06 21:48:29.264203', NULL, 'admin', NULL, '纯化磁珠(4号工位50uL)', NULL, 5, 'Reagent', 10, '磁珠', 16, '华大生物科技/股份公司/BGI', NULL, 'BGBD05', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (17, '2019-07-06 21:48:56.832673', NULL, 'admin', '2019-07-06 21:48:56.832673', NULL, 'admin', NULL, 'TE(1、4号工位70uL)', NULL, 5, 'Reagent', 19, '洗脱液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGTE01', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (18, '2019-07-06 21:49:17.502654', NULL, 'admin', '2019-07-06 21:49:17.502654', NULL, 'admin', NULL, 'TE(2号工位94uL)', NULL, 5, 'Reagent', 19, '洗脱液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGTE02', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (19, '2019-07-06 21:49:39.295483', NULL, 'admin', '2019-07-06 21:49:39.295483', NULL, 'admin', NULL, 'TE(3号工位46uL)', NULL, 5, 'Reagent', 19, '洗脱液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGTE03', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (41, '2019-07-29 11:03:20.686985', NULL, 'admin', '2019-11-19 14:59:11.61115', NULL, 'admin', NULL, '金源250uL有滤芯吸头(拔2个)', NULL, 4, 'Tips', 24, '普通有滤芯吸头', 8, '金源', NULL, 'GETF02', NULL, NULL, NULL, 3, 'MGRK02');
INSERT INTO "public"."material" VALUES (11, '2019-07-06 21:45:05.890468', NULL, 'admin', '2019-11-19 14:59:02.718252', NULL, 'admin', NULL, '金源250uL无滤芯吸头(拔2个)', NULL, 4, 'Tips', 6, '吸头', 8, '金源', NULL, 'GETP02', NULL, NULL, NULL, 3, 'MGRK02');
INSERT INTO "public"."material" VALUES (43, '2019-07-29 11:13:29.070994', NULL, 'admin', '2019-11-18 14:30:00.992081', NULL, 'admin', NULL, 'PCR密封垫', NULL, 8, 'PCRLid', 22, 'PCR密封垫', 1, '华大智造/MGI', NULL, 'MGPL01', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (2, '2019-07-06 21:31:10.83521', NULL, 'admin', '2019-12-24 15:39:51.26002', NULL, 'admin', NULL, '4层堆栈料架（1mL）', NULL, 1, 'Rack', 2, '料架', 1, '华大智造/MGI', 'NIFTY产线Hamilton吸头（1mL）', 'MGRK01', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (10, '2019-07-06 21:45:05.854026', NULL, 'admin', '2019-11-19 14:58:57.810414', NULL, 'admin', NULL, '金源250uL无滤芯吸头', NULL, 4, 'Tips', 6, '吸头', 8, '金源', NULL, 'GETP01', NULL, NULL, NULL, 3, 'MGRK02');
INSERT INTO "public"."material" VALUES (42, '2019-07-29 11:05:12.693799', NULL, 'admin', '2019-10-31 11:52:22.178444', NULL, 'admin', NULL, '透明50uL无滤芯吸头', NULL, 4, 'Tips', 6, '普通无滤芯吸头', 11, '康荣', NULL, 'CRTP01', NULL, NULL, NULL, 7, 'MGRK06');
INSERT INTO "public"."material" VALUES (40, '2019-07-29 11:02:18.278585', NULL, 'admin', '2019-11-19 14:59:07.069524', NULL, 'admin', NULL, '金源250uL有滤芯吸头', NULL, 4, 'Tips', 24, '普通有滤芯吸头', 8, '金源', NULL, 'GETF01', NULL, NULL, NULL, 3, 'MGRK02');
INSERT INTO "public"."material" VALUES (45, '2019-07-29 11:18:25.201802', NULL, 'admin', '2019-10-31 11:52:28.932935', NULL, 'admin', NULL, '透明300uL无滤芯吸头', NULL, 4, 'Tips', 6, '普通无滤芯吸头', 11, '康荣', NULL, 'CRTP02', NULL, NULL, NULL, 7, 'MGRK06');
INSERT INTO "public"."material" VALUES (46, '2019-07-29 11:18:48.537039', NULL, 'admin', '2019-10-31 11:53:01.214819', NULL, 'admin', NULL, '透明1000uL无滤芯吸头', NULL, 4, 'Tips', 6, '普通无滤芯吸头', 11, '康荣', NULL, 'CRTP03', NULL, NULL, NULL, 2, 'MGRK01');
INSERT INTO "public"."material" VALUES (47, '2019-07-29 11:19:12.654235', NULL, 'admin', '2019-10-31 11:53:08.074536', NULL, 'admin', NULL, '透明50uL有滤芯吸头', NULL, 4, 'Tips', 24, '普通有滤芯吸头', 11, '康荣', NULL, 'CRTF01', NULL, NULL, NULL, 7, 'MGRK06');
INSERT INTO "public"."material" VALUES (48, '2019-07-29 11:19:42.443422', NULL, 'admin', '2019-10-31 11:53:13.865495', NULL, 'admin', NULL, '透明300uL有滤芯吸头', NULL, 4, 'Tips', 24, '普通有滤芯吸头', 11, '康荣', NULL, 'CRTF02', NULL, NULL, NULL, 7, 'MGRK06');
INSERT INTO "public"."material" VALUES (49, '2019-07-29 11:19:58.131072', NULL, 'admin', '2019-10-31 11:53:20.193212', NULL, 'admin', NULL, '透明1000uL有滤芯吸头', NULL, 4, 'Tips', 24, '普通有滤芯吸头', 11, '康荣', NULL, 'CRTF03', NULL, NULL, NULL, 2, 'MGRK01');
INSERT INTO "public"."material" VALUES (50, '2019-07-29 11:20:19.888605', NULL, 'admin', '2019-10-31 11:53:27.500375', NULL, 'admin', NULL, '导电50uL无滤芯吸头', NULL, 4, 'Tips', 25, '导电无滤芯吸头', 11, '康荣', NULL, 'CRAP01', NULL, NULL, NULL, 7, 'MGRK06');
INSERT INTO "public"."material" VALUES (51, '2019-07-29 13:52:39.888188', NULL, 'admin', '2019-10-31 11:53:35.221221', NULL, 'admin', NULL, '导电300uL无滤芯吸头', NULL, 4, 'Tips', 25, '导电无滤芯吸头', 11, '康荣', NULL, 'CRAP02', NULL, NULL, NULL, 7, 'MGRK06');
INSERT INTO "public"."material" VALUES (52, '2019-07-29 13:53:47.798517', NULL, 'admin', '2019-10-31 11:53:41.913478', NULL, 'admin', NULL, '导电1000uL无滤芯吸头', NULL, 4, 'Tips', 25, '导电无滤芯吸头', 11, '康荣', NULL, 'CRAP03', NULL, NULL, NULL, 2, 'MGRK01');
INSERT INTO "public"."material" VALUES (53, '2019-07-29 14:09:12.344515', NULL, 'admin', '2019-10-31 11:53:48.421223', NULL, 'admin', NULL, '导电50uL有滤芯吸头', NULL, 4, 'Tips', 26, '导电有滤芯吸头', 11, '康荣', NULL, 'CRAF01', NULL, NULL, NULL, 7, 'MGRK06');
INSERT INTO "public"."material" VALUES (54, '2019-07-29 14:09:41.724418', NULL, 'admin', '2019-10-31 11:53:53.639295', NULL, 'admin', NULL, '导电300uL有滤芯吸头', NULL, 4, 'Tips', 26, '导电有滤芯吸头', 11, '康荣', NULL, 'CRAF02', NULL, NULL, NULL, 7, 'MGRK06');
INSERT INTO "public"."material" VALUES (55, '2019-07-29 14:10:12.770072', NULL, 'admin', '2019-10-31 11:54:01.484635', NULL, 'admin', NULL, '导电1000uL有滤芯吸头', NULL, 4, 'Tips', 26, '导电有滤芯吸头', 11, '康荣', NULL, 'CRAF03', NULL, NULL, NULL, 2, 'MGRK01');
INSERT INTO "public"."material" VALUES (44, '2019-07-29 11:15:36.120569', NULL, 'admin', '2019-11-15 09:59:31.729191', NULL, 'admin', NULL, 'PCR密封垫支架', NULL, 9, 'PCRLidHolder', 23, 'PCR密封垫支架', 1, '华大智造/MGI', NULL, 'MGPH01', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (7, '2019-07-06 21:39:11.890239', NULL, 'admin', '2019-12-24 15:40:29.887945', NULL, 'admin', NULL, '4层堆栈料架（50 & 300μL）', NULL, 1, 'Rack', 2, '料架', 1, '华大智造/MGI', '暂未使用', 'MGRK06', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (6, '2019-07-06 21:38:51.337768', NULL, 'admin', '2019-12-24 15:41:10.039614', NULL, 'admin', NULL, '7层堆栈料架（50 & 300μL）', NULL, 1, 'Rack', 2, '料架', 1, '华大智造/MGI', 'NIFTY&WGS产线Hamilton吸头（50 &300μL）', 'MGRK05', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (36, '2019-07-06 21:56:25.258059', NULL, 'admin', '2020-01-03 17:13:26.214585', NULL, 'admin', NULL, '基因库样本', NULL, 6, 'Sample', 20, '样本', 13, '国家基因库/GeneBank', NULL, 'GBSP12', NULL, 9, 'BRMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (20, '2019-07-06 21:49:57.699417', NULL, 'admin', '2019-07-06 21:49:57.699418', NULL, 'admin', NULL, '75%乙醇(300uL)', NULL, 5, 'Reagent', 9, '乙醇', 16, '华大生物科技/股份公司/BGI', NULL, 'BGET01', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (21, '2019-07-06 21:50:15.474982', NULL, 'admin', '2019-07-06 21:50:15.474983', NULL, 'admin', NULL, '裂解液', NULL, 5, 'Reagent', 16, '裂解液', 16, '华大生物科技/股份公司/BGI', NULL, 'BGLE01', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (22, '2019-07-06 21:50:35.61091', NULL, 'admin', '2019-07-06 21:50:35.610911', NULL, 'admin', NULL, '清洗液1', NULL, 5, 'Reagent', 17, '清洗液1', 16, '华大生物科技/股份公司/BGI', NULL, 'BGW101', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (23, '2019-07-06 21:50:49.747487', NULL, 'admin', '2019-07-06 21:50:49.747487', NULL, 'admin', NULL, '清洗液2', NULL, 5, 'Reagent', 18, '清洗液2', 16, '华大生物科技/股份公司/BGI', NULL, 'BGW201', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (35, '2019-07-06 21:56:01.277047', NULL, 'admin', '2019-09-06 18:01:59.553103', NULL, 'admin', NULL, '股份公司样本', NULL, 6, 'Sample', 20, '样本', 16, '华大生物科技/股份公司/BGI', NULL, 'BGSP15', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (73, '2019-10-22 18:37:04.652906', NULL, 'admin', '2019-12-12 09:48:12.032628', NULL, 'admin', NULL, 'Dig Enzyme-工位3-96XL-MST', NULL, 5, 'Reagent', 11, '酶', 13, '国家基因库/GeneBank', NULL, 'GBEZ04', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (74, '2019-10-22 18:37:40.426355', NULL, 'admin', '2019-12-12 09:48:17.81199', NULL, 'admin', NULL, 'Barcode-工位3-96XL-MST', NULL, 5, 'Reagent', 15, '接头', 13, '国家基因库/GeneBank', NULL, 'GBBC01', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (61, '2019-10-22 18:29:46.350143', NULL, 'admin', '2019-12-12 09:47:30.552868', NULL, 'admin', NULL, 'Ad Enhancer-工位3-96XL-MST', NULL, 5, 'Reagent', 7, '缓冲液', 13, '国家基因库/GeneBank', NULL, 'GBBF03', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (80, '2019-10-27 16:37:18.11345', NULL, 'admin', '2019-10-31 15:43:44.507503', NULL, 'admin', NULL, '21层冰箱料架', NULL, 1, 'Rack', 2, '料架', 2, 'Thermo', NULL, 'TMRK02', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (66, '2019-10-22 18:34:04.951659', NULL, 'admin', '2019-12-12 09:46:31.285864', NULL, 'admin', NULL, 'BeadsSmall-工位2-96XL-DNDW', NULL, 5, 'Reagent', 10, '磁珠', 13, '国家基因库/GeneBank', NULL, 'GBBD02', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (9, '2019-07-06 21:43:51.315221', NULL, 'admin', '2019-10-29 14:03:33.179574', NULL, 'admin', NULL, 'Bio-Rad全裙边PCR板', NULL, 3, 'Consumable', 4, 'PCR板', 4, 'Bio-Rad', '基准', 'BRMW01', NULL, NULL, NULL, 5, 'MGRK04');
INSERT INTO "public"."material" VALUES (67, '2019-10-22 18:34:27.689649', NULL, 'admin', '2019-12-12 09:46:37.43553', NULL, 'admin', NULL, 'Beads-工位4-96XL-DNDW', NULL, 5, 'Reagent', 10, '磁珠', 13, '国家基因库/GeneBank', NULL, 'GBBD03', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (57, '2019-10-22 17:58:11.488251', NULL, 'admin', '2019-10-29 14:03:53.918251', NULL, 'admin', NULL, '美森特全裙边PCR板', NULL, 3, 'Consumable', 4, 'PCR板', 5, '美森特', NULL, 'MSMW01', NULL, NULL, NULL, 5, 'MGRK04');
INSERT INTO "public"."material" VALUES (37, '2019-07-24 14:24:15.080072', NULL, 'admin', '2019-10-29 15:16:38.022207', NULL, 'admin', NULL, '酶标板', NULL, 3, 'Consumable', 5, '酶标板', 7, 'Eppendorf', '暂时不在SP系列使用', 'EDUV01', NULL, NULL, NULL, 5, 'MGRK04');
INSERT INTO "public"."material" VALUES (75, '2019-10-22 18:38:10.131209', NULL, 'admin', '2019-12-12 09:48:24.449247', NULL, 'admin', NULL, 'PCR Primer-工位3-96XL-MST', NULL, 5, 'Reagent', 13, '引物', 13, '国家基因库/GeneBank', NULL, 'GBPM01', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (62, '2019-10-22 18:30:45.2917', NULL, 'admin', '2019-12-12 09:47:35.629571', NULL, 'admin', NULL, 'Cir Buffer-工位3-96XL-MST', NULL, 5, 'Reagent', 7, '缓冲液', 13, '国家基因库/GeneBank', NULL, 'GBBF04', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (58, '2019-10-22 18:07:39.013914', NULL, 'admin', '2019-12-12 09:46:05.832968', NULL, 'admin', NULL, 'TE-96XL-DNDW', NULL, 5, 'Reagent', 19, '洗脱液', 13, '国家基因库/GeneBank', NULL, 'GBTE01', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (64, '2019-10-22 18:32:32.5081', NULL, 'admin', '2019-12-12 09:46:19.493029', NULL, 'admin', NULL, 'Ethanol80%-96XL-DNDW', NULL, 5, 'Reagent', 9, '乙醇', 13, '国家基因库/GeneBank', NULL, 'GBET01', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (68, '2019-10-22 18:34:51.445039', NULL, 'admin', '2019-12-12 09:46:44.526126', NULL, 'admin', NULL, 'Beads-工位5-96XL-DNDW', NULL, 5, 'Reagent', 10, '磁珠', 13, '国家基因库/GeneBank', NULL, 'GBBD04', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (79, '2019-10-27 16:36:39.762305', NULL, 'admin', '2019-10-31 15:43:35.198748', NULL, 'admin', NULL, '10层冰箱料架', NULL, 1, 'Rack', 2, '料架', 2, 'Thermo', NULL, 'TMRK01', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (69, '2019-10-22 18:35:15.456573', NULL, 'admin', '2019-12-12 09:46:52.813234', NULL, 'admin', NULL, 'Beads-工位7-96XL-DNDW', NULL, 5, 'Reagent', 10, '磁珠', 13, '国家基因库/GeneBank', NULL, 'GBBD05', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (63, '2019-10-22 18:31:11.76614', NULL, 'admin', '2019-12-12 09:47:41.843005', NULL, 'admin', NULL, 'Dig Buffer-工位3-96XL-MST', NULL, 5, 'Reagent', 7, '缓冲液', 13, '国家基因库/GeneBank', NULL, 'GBBF05', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (56, '2019-08-22 16:24:38.191272', NULL, 'admin', '2019-11-18 16:17:29.711649', NULL, 'admin', NULL, '蒂恩1.3mL圆底深孔板', NULL, 3, 'Consumable', 3, '深孔板', 3, '东莞蒂恩', '', 'DNDW01', NULL, NULL, NULL, 4, 'MGRK03');
INSERT INTO "public"."material" VALUES (70, '2019-10-22 18:35:47.752217', NULL, 'admin', '2019-12-12 09:47:54.365184', NULL, 'admin', NULL, 'ER Enzyme-工位3-96XL-MST', NULL, 5, 'Reagent', 11, '酶', 13, '国家基因库/GeneBank', NULL, 'GBEZ01', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (82, '2019-12-11 17:33:09.338097', NULL, 'admin', '2019-12-11 17:33:09.338104', NULL, 'admin', NULL, '酶标板配平板(63g)', NULL, 10, 'BalancedPlate', 27, '配平板', 1, '华大智造/MGI', NULL, 'MGBP01', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (83, '2019-12-11 17:34:08.07332', NULL, 'admin', '2019-12-11 17:34:08.073327', NULL, 'admin', NULL, '全裙边PCR板配平板(40g)', NULL, 10, 'BalancedPlate', 27, '配平板', 1, '华大智造/MGI', NULL, 'MGBP02', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (84, '2019-12-11 17:35:14.216998', NULL, 'admin', '2019-12-11 17:35:14.217', NULL, 'admin', NULL, '深孔板配平板(80g)', NULL, 10, 'BalancedPlate', 27, '配平板', 1, '华大智造/MGI', NULL, 'MGBP03', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material" VALUES (71, '2019-10-22 18:36:18.766367', NULL, 'admin', '2019-12-12 09:47:59.483113', NULL, 'admin', NULL, 'Ad Enzyme-工位3-96XL-MST', NULL, 5, 'Reagent', 11, '酶', 13, '国家基因库/GeneBank', NULL, 'GBEZ02', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (72, '2019-10-22 18:36:43.528042', NULL, 'admin', '2019-12-12 09:48:06.382708', NULL, 'admin', NULL, 'Cir Enzyme-工位3-96XL-MST', NULL, 5, 'Reagent', 11, '酶', 13, '国家基因库/GeneBank', NULL, 'GBEZ03', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (76, '2019-10-22 18:38:37.078593', NULL, 'admin', '2019-12-12 09:48:30.707437', NULL, 'admin', NULL, 'PCR Mix-工位3-96XL-MST', NULL, 5, 'Reagent', 12, '混合液', 13, '国家基因库/GeneBank', NULL, 'GBMX01', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (77, '2019-10-22 18:43:20.008728', NULL, 'admin', '2019-12-12 09:48:37.9852', NULL, 'admin', NULL, 'PCR Water-工位3-96XL-MST', NULL, 5, 'Reagent', 14, '水', 13, '国家基因库/GeneBank', NULL, 'GBWT01', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (78, '2019-10-22 18:43:47.988888', NULL, 'admin', '2019-12-12 09:48:44.516164', NULL, 'admin', NULL, 'Oligo-工位3-96XL-MST', NULL, 5, 'Reagent', 13, '引物', 13, '国家基因库/GeneBank', NULL, 'GBPM02', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (65, '2019-10-22 18:33:34.607553', NULL, 'admin', '2019-12-12 09:46:25.422399', NULL, 'admin', NULL, 'BeadsLarge-工位2-96XL-DNDW', NULL, 5, 'Reagent', 10, '磁珠', 13, '国家基因库/GeneBank', NULL, 'GBBD01', NULL, 56, 'DNDW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (59, '2019-10-22 18:09:20.43363', NULL, 'admin', '2019-12-12 09:47:19.847135', NULL, 'admin', NULL, 'ER Buffer-工位3-96XL-MST', NULL, 5, 'Reagent', 7, '缓冲液', 13, '国家基因库/GeneBank', NULL, 'GBBF01', NULL, 57, 'MSMW01', NULL, NULL);
INSERT INTO "public"."material" VALUES (60, '2019-10-22 18:28:09.562063', NULL, 'admin', '2019-12-12 09:47:25.939983', NULL, 'admin', NULL, 'Ad Buffer-工位3-96XL-MST', NULL, 5, 'Reagent', 7, '缓冲液', 13, '国家基因库/GeneBank', NULL, 'GBBF02', NULL, 57, 'MSMW01', NULL, NULL);

-- ----------------------------
-- Table structure for material_brand
-- ----------------------------
DROP TABLE IF EXISTS "public"."material_brand";
CREATE TABLE "public"."material_brand" (
  "id" int4 NOT NULL DEFAULT nextval('material_brand_id_seq'::regclass),
  "create_time" timestamp(6),
  "create_user_id" int4,
  "create_user_name" text COLLATE "pg_catalog"."default",
  "modify_time" timestamp(6),
  "modify_user_id" int4,
  "modify_user_name" text COLLATE "pg_catalog"."default",
  "code" text COLLATE "pg_catalog"."default",
  "name" text COLLATE "pg_catalog"."default",
  "en_name" text COLLATE "pg_catalog"."default",
  "desc" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of material_brand
-- ----------------------------
INSERT INTO "public"."material_brand" VALUES (2, '2019-07-03 11:02:19.378913', NULL, 'admin', '2019-07-03 11:02:19.378994', NULL, 'admin', 'TM', 'Thermo', NULL, '');
INSERT INTO "public"."material_brand" VALUES (3, '2019-07-03 11:02:49.768332', NULL, 'admin', '2019-07-03 11:02:49.768338', NULL, 'admin', 'DN', '东莞蒂恩', NULL, '');
INSERT INTO "public"."material_brand" VALUES (4, '2019-07-03 11:02:59.983162', NULL, 'admin', '2019-07-03 11:02:59.983163', NULL, 'admin', 'BR', 'Bio-Rad', NULL, '');
INSERT INTO "public"."material_brand" VALUES (5, '2019-07-03 11:03:08.766997', NULL, 'admin', '2019-07-03 11:03:08.766997', NULL, 'admin', 'MS', '美森特', NULL, '');
INSERT INTO "public"."material_brand" VALUES (6, '2019-07-03 11:03:38.59234', NULL, 'admin', '2019-07-03 11:03:38.592341', NULL, 'admin', 'AG', 'Axygen', NULL, '');
INSERT INTO "public"."material_brand" VALUES (7, '2019-07-03 11:03:48.952302', NULL, 'admin', '2019-07-03 11:03:48.952302', NULL, 'admin', 'ED', 'Eppendorf', NULL, '');
INSERT INTO "public"."material_brand" VALUES (8, '2019-07-03 11:03:57.42332', NULL, 'admin', '2019-07-03 11:03:57.42332', NULL, 'admin', 'GE', '金源', NULL, '');
INSERT INTO "public"."material_brand" VALUES (9, '2019-07-03 11:04:06.33636', NULL, 'admin', '2019-07-03 11:04:06.336361', NULL, 'admin', 'HM', 'Hamilton', NULL, '');
INSERT INTO "public"."material_brand" VALUES (11, '2019-07-03 11:04:23.408595', NULL, 'admin', '2019-07-03 11:04:23.408596', NULL, 'admin', 'CR', '康荣', NULL, '');
INSERT INTO "public"."material_brand" VALUES (12, '2019-07-03 11:04:31.547857', NULL, 'admin', '2019-07-03 11:04:31.547857', NULL, 'admin', 'NB', 'NEB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (13, '2019-07-03 11:04:40.155779', NULL, 'admin', '2019-07-03 11:04:40.155779', NULL, 'admin', 'GB', '国家基因库/GeneBank', NULL, '');
INSERT INTO "public"."material_brand" VALUES (14, '2019-07-03 11:04:48.8003', NULL, 'admin', '2019-07-03 11:04:48.800301', NULL, 'admin', 'VZ', 'Vazyme', NULL, '');
INSERT INTO "public"."material_brand" VALUES (15, '2019-07-03 11:04:56.872247', NULL, 'admin', '2019-07-03 11:04:56.872248', NULL, 'admin', 'PG', 'PEG', NULL, '');
INSERT INTO "public"."material_brand" VALUES (16, '2019-07-03 11:05:06.912422', NULL, 'admin', '2019-07-03 11:05:06.912422', NULL, 'admin', 'BG', '华大生物科技/股份公司/BGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (1, '2019-06-27 13:28:03.865716', NULL, 'admin', '2019-07-06 14:55:00.88615', NULL, 'admin', 'MG', '华大智造/MGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (17, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (18, '2020-02-11 15:35:43.675424', NULL, 'admin', '2020-02-11 15:35:43.675425', NULL, 'admin', 'BB', 'BB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (19, '2020-02-11 15:35:50.040556', NULL, 'admin', '2020-02-11 15:35:50.040557', NULL, 'admin', 'CC', 'CC', NULL, '');
INSERT INTO "public"."material_brand" VALUES (20, '2020-02-11 15:35:56.350095', NULL, 'admin', '2020-02-11 15:35:56.350096', NULL, 'admin', 'DD', 'DD', NULL, '');
INSERT INTO "public"."material_brand" VALUES (21, '2019-07-03 11:02:19.378913', NULL, 'admin', '2019-07-03 11:02:19.378994', NULL, 'admin', 'TM', 'Thermo', NULL, '');
INSERT INTO "public"."material_brand" VALUES (22, '2019-07-03 11:02:49.768332', NULL, 'admin', '2019-07-03 11:02:49.768338', NULL, 'admin', 'DN', '东莞蒂恩', NULL, '');
INSERT INTO "public"."material_brand" VALUES (23, '2019-07-03 11:02:59.983162', NULL, 'admin', '2019-07-03 11:02:59.983163', NULL, 'admin', 'BR', 'Bio-Rad', NULL, '');
INSERT INTO "public"."material_brand" VALUES (24, '2019-07-03 11:03:08.766997', NULL, 'admin', '2019-07-03 11:03:08.766997', NULL, 'admin', 'MS', '美森特', NULL, '');
INSERT INTO "public"."material_brand" VALUES (25, '2019-07-03 11:03:38.59234', NULL, 'admin', '2019-07-03 11:03:38.592341', NULL, 'admin', 'AG', 'Axygen', NULL, '');
INSERT INTO "public"."material_brand" VALUES (26, '2019-07-03 11:03:48.952302', NULL, 'admin', '2019-07-03 11:03:48.952302', NULL, 'admin', 'ED', 'Eppendorf', NULL, '');
INSERT INTO "public"."material_brand" VALUES (27, '2019-07-03 11:03:57.42332', NULL, 'admin', '2019-07-03 11:03:57.42332', NULL, 'admin', 'GE', '金源', NULL, '');
INSERT INTO "public"."material_brand" VALUES (28, '2019-07-03 11:04:06.33636', NULL, 'admin', '2019-07-03 11:04:06.336361', NULL, 'admin', 'HM', 'Hamilton', NULL, '');
INSERT INTO "public"."material_brand" VALUES (29, '2019-07-03 11:04:14.301037', NULL, 'admin', '2019-07-03 11:04:14.301038', NULL, 'admin', 'AL', 'Agilent', NULL, '');
INSERT INTO "public"."material_brand" VALUES (31, '2019-07-03 11:04:31.547857', NULL, 'admin', '2019-07-03 11:04:31.547857', NULL, 'admin', 'NB', 'NEB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (32, '2019-07-03 11:04:40.155779', NULL, 'admin', '2019-07-03 11:04:40.155779', NULL, 'admin', 'GB', '国家基因库/GeneBank', NULL, '');
INSERT INTO "public"."material_brand" VALUES (33, '2019-07-03 11:04:48.8003', NULL, 'admin', '2019-07-03 11:04:48.800301', NULL, 'admin', 'VZ', 'Vazyme', NULL, '');
INSERT INTO "public"."material_brand" VALUES (34, '2019-07-03 11:04:56.872247', NULL, 'admin', '2019-07-03 11:04:56.872248', NULL, 'admin', 'PG', 'PEG', NULL, '');
INSERT INTO "public"."material_brand" VALUES (35, '2019-07-03 11:05:06.912422', NULL, 'admin', '2019-07-03 11:05:06.912422', NULL, 'admin', 'BG', '华大生物科技/股份公司/BGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (36, '2019-06-27 13:28:03.865716', NULL, 'admin', '2019-07-06 14:55:00.88615', NULL, 'admin', 'MG', '华大智造/MGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (37, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (38, '2020-02-11 15:35:43.675424', NULL, 'admin', '2020-02-11 15:35:43.675425', NULL, 'admin', 'BB', 'BB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (39, '2020-02-11 15:35:50.040556', NULL, 'admin', '2020-02-11 15:35:50.040557', NULL, 'admin', 'CC', 'CC', NULL, '');
INSERT INTO "public"."material_brand" VALUES (40, '2020-02-11 15:35:56.350095', NULL, 'admin', '2020-02-11 15:35:56.350096', NULL, 'admin', 'DD', 'DD', NULL, '');
INSERT INTO "public"."material_brand" VALUES (41, '2019-07-03 11:02:19.378913', NULL, 'admin', '2019-07-03 11:02:19.378994', NULL, 'admin', 'TM', 'Thermo', NULL, '');
INSERT INTO "public"."material_brand" VALUES (42, '2019-07-03 11:02:49.768332', NULL, 'admin', '2019-07-03 11:02:49.768338', NULL, 'admin', 'DN', '东莞蒂恩', NULL, '');
INSERT INTO "public"."material_brand" VALUES (43, '2019-07-03 11:02:59.983162', NULL, 'admin', '2019-07-03 11:02:59.983163', NULL, 'admin', 'BR', 'Bio-Rad', NULL, '');
INSERT INTO "public"."material_brand" VALUES (44, '2019-07-03 11:03:08.766997', NULL, 'admin', '2019-07-03 11:03:08.766997', NULL, 'admin', 'MS', '美森特', NULL, '');
INSERT INTO "public"."material_brand" VALUES (45, '2019-07-03 11:03:38.59234', NULL, 'admin', '2019-07-03 11:03:38.592341', NULL, 'admin', 'AG', 'Axygen', NULL, '');
INSERT INTO "public"."material_brand" VALUES (46, '2019-07-03 11:03:48.952302', NULL, 'admin', '2019-07-03 11:03:48.952302', NULL, 'admin', 'ED', 'Eppendorf', NULL, '');
INSERT INTO "public"."material_brand" VALUES (47, '2019-07-03 11:03:57.42332', NULL, 'admin', '2019-07-03 11:03:57.42332', NULL, 'admin', 'GE', '金源', NULL, '');
INSERT INTO "public"."material_brand" VALUES (48, '2019-07-03 11:04:06.33636', NULL, 'admin', '2019-07-03 11:04:06.336361', NULL, 'admin', 'HM', 'Hamilton', NULL, '');
INSERT INTO "public"."material_brand" VALUES (49, '2019-07-03 11:04:14.301037', NULL, 'admin', '2019-07-03 11:04:14.301038', NULL, 'admin', 'AL', 'Agilent', NULL, '');
INSERT INTO "public"."material_brand" VALUES (50, '2019-07-03 11:04:23.408595', NULL, 'admin', '2019-07-03 11:04:23.408596', NULL, 'admin', 'CR', '康荣', NULL, '');
INSERT INTO "public"."material_brand" VALUES (51, '2019-07-03 11:04:31.547857', NULL, 'admin', '2019-07-03 11:04:31.547857', NULL, 'admin', 'NB', 'NEB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (52, '2019-07-03 11:04:40.155779', NULL, 'admin', '2019-07-03 11:04:40.155779', NULL, 'admin', 'GB', '国家基因库/GeneBank', NULL, '');
INSERT INTO "public"."material_brand" VALUES (53, '2019-07-03 11:04:48.8003', NULL, 'admin', '2019-07-03 11:04:48.800301', NULL, 'admin', 'VZ', 'Vazyme', NULL, '');
INSERT INTO "public"."material_brand" VALUES (54, '2019-07-03 11:04:56.872247', NULL, 'admin', '2019-07-03 11:04:56.872248', NULL, 'admin', 'PG', 'PEG', NULL, '');
INSERT INTO "public"."material_brand" VALUES (55, '2019-07-03 11:05:06.912422', NULL, 'admin', '2019-07-03 11:05:06.912422', NULL, 'admin', 'BG', '华大生物科技/股份公司/BGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (56, '2019-06-27 13:28:03.865716', NULL, 'admin', '2019-07-06 14:55:00.88615', NULL, 'admin', 'MG', '华大智造/MGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (57, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (58, '2020-02-11 15:35:43.675424', NULL, 'admin', '2020-02-11 15:35:43.675425', NULL, 'admin', 'BB', 'BB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (59, '2020-02-11 15:35:50.040556', NULL, 'admin', '2020-02-11 15:35:50.040557', NULL, 'admin', 'CC', 'CC', NULL, '');
INSERT INTO "public"."material_brand" VALUES (60, '2020-02-11 15:35:56.350095', NULL, 'admin', '2020-02-11 15:35:56.350096', NULL, 'admin', 'DD', 'DD', NULL, '');
INSERT INTO "public"."material_brand" VALUES (62, '2019-07-03 11:02:49.768332', NULL, 'admin', '2019-07-03 11:02:49.768338', NULL, 'admin', 'DN', '东莞蒂恩', NULL, '');
INSERT INTO "public"."material_brand" VALUES (63, '2019-07-03 11:02:59.983162', NULL, 'admin', '2019-07-03 11:02:59.983163', NULL, 'admin', 'BR', 'Bio-Rad', NULL, '');
INSERT INTO "public"."material_brand" VALUES (64, '2019-07-03 11:03:08.766997', NULL, 'admin', '2019-07-03 11:03:08.766997', NULL, 'admin', 'MS', '美森特', NULL, '');
INSERT INTO "public"."material_brand" VALUES (65, '2019-07-03 11:03:38.59234', NULL, 'admin', '2019-07-03 11:03:38.592341', NULL, 'admin', 'AG', 'Axygen', NULL, '');
INSERT INTO "public"."material_brand" VALUES (66, '2019-07-03 11:03:48.952302', NULL, 'admin', '2019-07-03 11:03:48.952302', NULL, 'admin', 'ED', 'Eppendorf', NULL, '');
INSERT INTO "public"."material_brand" VALUES (67, '2019-07-03 11:03:57.42332', NULL, 'admin', '2019-07-03 11:03:57.42332', NULL, 'admin', 'GE', '金源', NULL, '');
INSERT INTO "public"."material_brand" VALUES (68, '2019-07-03 11:04:06.33636', NULL, 'admin', '2019-07-03 11:04:06.336361', NULL, 'admin', 'HM', 'Hamilton', NULL, '');
INSERT INTO "public"."material_brand" VALUES (69, '2019-07-03 11:04:14.301037', NULL, 'admin', '2019-07-03 11:04:14.301038', NULL, 'admin', 'AL', 'Agilent', NULL, '');
INSERT INTO "public"."material_brand" VALUES (70, '2019-07-03 11:04:23.408595', NULL, 'admin', '2019-07-03 11:04:23.408596', NULL, 'admin', 'CR', '康荣', NULL, '');
INSERT INTO "public"."material_brand" VALUES (71, '2019-07-03 11:04:31.547857', NULL, 'admin', '2019-07-03 11:04:31.547857', NULL, 'admin', 'NB', 'NEB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (72, '2019-07-03 11:04:40.155779', NULL, 'admin', '2019-07-03 11:04:40.155779', NULL, 'admin', 'GB', '国家基因库/GeneBank', NULL, '');
INSERT INTO "public"."material_brand" VALUES (73, '2019-07-03 11:04:48.8003', NULL, 'admin', '2019-07-03 11:04:48.800301', NULL, 'admin', 'VZ', 'Vazyme', NULL, '');
INSERT INTO "public"."material_brand" VALUES (74, '2019-07-03 11:04:56.872247', NULL, 'admin', '2019-07-03 11:04:56.872248', NULL, 'admin', 'PG', 'PEG', NULL, '');
INSERT INTO "public"."material_brand" VALUES (75, '2019-07-03 11:05:06.912422', NULL, 'admin', '2019-07-03 11:05:06.912422', NULL, 'admin', 'BG', '华大生物科技/股份公司/BGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (76, '2019-06-27 13:28:03.865716', NULL, 'admin', '2019-07-06 14:55:00.88615', NULL, 'admin', 'MG', '华大智造/MGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (77, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (78, '2020-02-11 15:35:43.675424', NULL, 'admin', '2020-02-11 15:35:43.675425', NULL, 'admin', 'BB', 'BB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (79, '2020-02-11 15:35:50.040556', NULL, 'admin', '2020-02-11 15:35:50.040557', NULL, 'admin', 'CC', 'CC', NULL, '');
INSERT INTO "public"."material_brand" VALUES (80, '2020-02-11 15:35:56.350095', NULL, 'admin', '2020-02-11 15:35:56.350096', NULL, 'admin', 'DD', 'DD', NULL, '');
INSERT INTO "public"."material_brand" VALUES (81, '2019-07-03 11:02:19.378913', NULL, 'admin', '2019-07-03 11:02:19.378994', NULL, 'admin', 'TM', 'Thermo', NULL, '');
INSERT INTO "public"."material_brand" VALUES (82, '2019-07-03 11:02:49.768332', NULL, 'admin', '2019-07-03 11:02:49.768338', NULL, 'admin', 'DN', '东莞蒂恩', NULL, '');
INSERT INTO "public"."material_brand" VALUES (83, '2019-07-03 11:02:59.983162', NULL, 'admin', '2019-07-03 11:02:59.983163', NULL, 'admin', 'BR', 'Bio-Rad', NULL, '');
INSERT INTO "public"."material_brand" VALUES (84, '2019-07-03 11:03:08.766997', NULL, 'admin', '2019-07-03 11:03:08.766997', NULL, 'admin', 'MS', '美森特', NULL, '');
INSERT INTO "public"."material_brand" VALUES (85, '2019-07-03 11:03:38.59234', NULL, 'admin', '2019-07-03 11:03:38.592341', NULL, 'admin', 'AG', 'Axygen', NULL, '');
INSERT INTO "public"."material_brand" VALUES (86, '2019-07-03 11:03:48.952302', NULL, 'admin', '2019-07-03 11:03:48.952302', NULL, 'admin', 'ED', 'Eppendorf', NULL, '');
INSERT INTO "public"."material_brand" VALUES (87, '2019-07-03 11:03:57.42332', NULL, 'admin', '2019-07-03 11:03:57.42332', NULL, 'admin', 'GE', '金源', NULL, '');
INSERT INTO "public"."material_brand" VALUES (88, '2019-07-03 11:04:06.33636', NULL, 'admin', '2019-07-03 11:04:06.336361', NULL, 'admin', 'HM', 'Hamilton', NULL, '');
INSERT INTO "public"."material_brand" VALUES (89, '2019-07-03 11:04:14.301037', NULL, 'admin', '2019-07-03 11:04:14.301038', NULL, 'admin', 'AL', 'Agilent', NULL, '');
INSERT INTO "public"."material_brand" VALUES (90, '2019-07-03 11:04:23.408595', NULL, 'admin', '2019-07-03 11:04:23.408596', NULL, 'admin', 'CR', '康荣', NULL, '');
INSERT INTO "public"."material_brand" VALUES (91, '2019-07-03 11:04:31.547857', NULL, 'admin', '2019-07-03 11:04:31.547857', NULL, 'admin', 'NB', 'NEB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (92, '2019-07-03 11:04:40.155779', NULL, 'admin', '2019-07-03 11:04:40.155779', NULL, 'admin', 'GB', '国家基因库/GeneBank', NULL, '');
INSERT INTO "public"."material_brand" VALUES (93, '2019-07-03 11:04:48.8003', NULL, 'admin', '2019-07-03 11:04:48.800301', NULL, 'admin', 'VZ', 'Vazyme', NULL, '');
INSERT INTO "public"."material_brand" VALUES (94, '2019-07-03 11:04:56.872247', NULL, 'admin', '2019-07-03 11:04:56.872248', NULL, 'admin', 'PG', 'PEG', NULL, '');
INSERT INTO "public"."material_brand" VALUES (95, '2019-07-03 11:05:06.912422', NULL, 'admin', '2019-07-03 11:05:06.912422', NULL, 'admin', 'BG', '华大生物科技/股份公司/BGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (96, '2019-06-27 13:28:03.865716', NULL, 'admin', '2019-07-06 14:55:00.88615', NULL, 'admin', 'MG', '华大智造/MGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (97, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (98, '2020-02-11 15:35:43.675424', NULL, 'admin', '2020-02-11 15:35:43.675425', NULL, 'admin', 'BB', 'BB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (99, '2020-02-11 15:35:50.040556', NULL, 'admin', '2020-02-11 15:35:50.040557', NULL, 'admin', 'CC', 'CC', NULL, '');
INSERT INTO "public"."material_brand" VALUES (100, '2020-02-11 15:35:56.350095', NULL, 'admin', '2020-02-11 15:35:56.350096', NULL, 'admin', 'DD', 'DD', NULL, '');
INSERT INTO "public"."material_brand" VALUES (101, '2019-07-03 11:02:19.378913', NULL, 'admin', '2019-07-03 11:02:19.378994', NULL, 'admin', 'TM', 'Thermo', NULL, '');
INSERT INTO "public"."material_brand" VALUES (102, '2019-07-03 11:02:49.768332', NULL, 'admin', '2019-07-03 11:02:49.768338', NULL, 'admin', 'DN', '东莞蒂恩', NULL, '');
INSERT INTO "public"."material_brand" VALUES (103, '2019-07-03 11:02:59.983162', NULL, 'admin', '2019-07-03 11:02:59.983163', NULL, 'admin', 'BR', 'Bio-Rad', NULL, '');
INSERT INTO "public"."material_brand" VALUES (104, '2019-07-03 11:03:08.766997', NULL, 'admin', '2019-07-03 11:03:08.766997', NULL, 'admin', 'MS', '美森特', NULL, '');
INSERT INTO "public"."material_brand" VALUES (105, '2019-07-03 11:03:38.59234', NULL, 'admin', '2019-07-03 11:03:38.592341', NULL, 'admin', 'AG', 'Axygen', NULL, '');
INSERT INTO "public"."material_brand" VALUES (106, '2019-07-03 11:03:48.952302', NULL, 'admin', '2019-07-03 11:03:48.952302', NULL, 'admin', 'ED', 'Eppendorf', NULL, '');
INSERT INTO "public"."material_brand" VALUES (107, '2019-07-03 11:03:57.42332', NULL, 'admin', '2019-07-03 11:03:57.42332', NULL, 'admin', 'GE', '金源', NULL, '');
INSERT INTO "public"."material_brand" VALUES (108, '2019-07-03 11:04:06.33636', NULL, 'admin', '2019-07-03 11:04:06.336361', NULL, 'admin', 'HM', 'Hamilton', NULL, '');
INSERT INTO "public"."material_brand" VALUES (109, '2019-07-03 11:04:14.301037', NULL, 'admin', '2019-07-03 11:04:14.301038', NULL, 'admin', 'AL', 'Agilent', NULL, '');
INSERT INTO "public"."material_brand" VALUES (110, '2019-07-03 11:04:23.408595', NULL, 'admin', '2019-07-03 11:04:23.408596', NULL, 'admin', 'CR', '康荣', NULL, '');
INSERT INTO "public"."material_brand" VALUES (111, '2019-07-03 11:04:31.547857', NULL, 'admin', '2019-07-03 11:04:31.547857', NULL, 'admin', 'NB', 'NEB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (112, '2019-07-03 11:04:40.155779', NULL, 'admin', '2019-07-03 11:04:40.155779', NULL, 'admin', 'GB', '国家基因库/GeneBank', NULL, '');
INSERT INTO "public"."material_brand" VALUES (113, '2019-07-03 11:04:48.8003', NULL, 'admin', '2019-07-03 11:04:48.800301', NULL, 'admin', 'VZ', 'Vazyme', NULL, '');
INSERT INTO "public"."material_brand" VALUES (114, '2019-07-03 11:04:56.872247', NULL, 'admin', '2019-07-03 11:04:56.872248', NULL, 'admin', 'PG', 'PEG', NULL, '');
INSERT INTO "public"."material_brand" VALUES (115, '2019-07-03 11:05:06.912422', NULL, 'admin', '2019-07-03 11:05:06.912422', NULL, 'admin', 'BG', '华大生物科技/股份公司/BGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (116, '2019-06-27 13:28:03.865716', NULL, 'admin', '2019-07-06 14:55:00.88615', NULL, 'admin', 'MG', '华大智造/MGI', NULL, '');
INSERT INTO "public"."material_brand" VALUES (117, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (118, '2020-02-11 15:35:43.675424', NULL, 'admin', '2020-02-11 15:35:43.675425', NULL, 'admin', 'BB', 'BB', NULL, '');
INSERT INTO "public"."material_brand" VALUES (119, '2020-02-11 15:35:50.040556', NULL, 'admin', '2020-02-11 15:35:50.040557', NULL, 'admin', 'CC', 'CC', NULL, '');
INSERT INTO "public"."material_brand" VALUES (120, '2020-02-11 15:35:56.350095', NULL, 'admin', '2020-02-11 15:35:56.350096', NULL, 'admin', 'DD', 'DD', NULL, '');
INSERT INTO "public"."material_brand" VALUES (121, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (122, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (123, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (124, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (125, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (126, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (127, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (128, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (129, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (130, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (131, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (132, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (133, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (134, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (135, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (136, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (137, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (138, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (139, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (140, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (141, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (142, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (143, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (144, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (145, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (146, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (147, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (148, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (149, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (150, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (151, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (152, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (153, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (154, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (155, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (156, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (157, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (158, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (159, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (160, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (161, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (162, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (163, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (164, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (165, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (166, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (167, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (168, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (169, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (170, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (171, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (172, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (173, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (174, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (175, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (176, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (177, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (178, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (179, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (180, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (181, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (182, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (183, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (184, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (185, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (186, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (187, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (188, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (189, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (190, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (191, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (192, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (193, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (194, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (195, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (196, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (197, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (198, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (199, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (200, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (201, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (202, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (203, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (204, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (205, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (206, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (207, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (208, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (209, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (210, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (211, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (212, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (213, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (214, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (215, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (216, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (217, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (218, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (219, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (220, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (221, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (222, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (223, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (224, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (225, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (226, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (227, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (228, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (229, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (230, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (231, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (232, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (233, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (234, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (235, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (236, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (237, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (238, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (239, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (240, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (241, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (242, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (243, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (244, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (245, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (246, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (247, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (248, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (249, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (250, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (251, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (252, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (253, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (254, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (255, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (256, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (257, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (258, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (259, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (260, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (261, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (262, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (263, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (264, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (265, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (266, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');
INSERT INTO "public"."material_brand" VALUES (267, '2020-02-11 15:35:36.700648', NULL, 'admin', '2020-02-11 15:35:36.700786', NULL, 'admin', 'AA', 'AA', NULL, '');

-- ----------------------------
-- Table structure for material_category
-- ----------------------------
DROP TABLE IF EXISTS "public"."material_category";
CREATE TABLE "public"."material_category" (
  "id" int4 NOT NULL DEFAULT nextval('material_category_id_seq'::regclass),
  "create_time" timestamp(6),
  "create_user_id" int4,
  "create_user_name" text COLLATE "pg_catalog"."default",
  "modify_time" timestamp(6),
  "modify_user_id" int4,
  "modify_user_name" text COLLATE "pg_catalog"."default",
  "code" text COLLATE "pg_catalog"."default",
  "name" text COLLATE "pg_catalog"."default",
  "en_name" text COLLATE "pg_catalog"."default",
  "require_container" bool,
  "manual_partnumber" bool,
  "require_rack" bool,
  "desc" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of material_category
-- ----------------------------
INSERT INTO "public"."material_category" VALUES (8, '2019-07-24 13:32:33.941389', NULL, 'admin', '2019-07-24 13:57:56.485313', NULL, 'admin', 'PCRLid', 'PCR密封垫', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material_category" VALUES (4, '2019-07-05 17:22:20.293119', NULL, 'admin', '2019-07-06 21:03:12.524797', NULL, 'admin', 'Tips', '吸头', NULL, NULL, NULL, 't', NULL);
INSERT INTO "public"."material_category" VALUES (7, '2019-07-05 17:49:06.748546', NULL, 'admin', '2019-09-07 10:48:30.742748', NULL, 'admin', 'InterSample', '中间样本', NULL, 't', NULL, NULL, NULL);
INSERT INTO "public"."material_category" VALUES (1, NULL, NULL, NULL, '2019-09-11 17:42:54.258104', NULL, 'admin', 'Rack', '料架', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material_category" VALUES (9, '2019-07-24 13:32:50.701113', NULL, 'admin', '2019-09-11 17:17:02.497292', NULL, 'admin', 'PCRLidHolder', 'PCR密封垫支架', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material_category" VALUES (3, '2019-07-05 16:27:18.614496', NULL, 'admin', '2019-11-29 17:26:40.25502', NULL, 'admin', 'Consumable', '耗材', NULL, 'f', NULL, 't', NULL);
INSERT INTO "public"."material_category" VALUES (5, '2019-07-05 17:25:33.493814', NULL, 'admin', '2019-11-29 17:34:00.803262', NULL, 'admin', 'Reagent', '试剂', NULL, 't', NULL, NULL, NULL);
INSERT INTO "public"."material_category" VALUES (10, '2019-12-11 17:26:16.464821', NULL, 'admin', '2019-12-11 17:26:16.46483', NULL, 'admin', 'BalancedPlate', '配平板', NULL, NULL, NULL, NULL, NULL);
INSERT INTO "public"."material_category" VALUES (6, '2019-07-05 17:48:35.06597', NULL, 'admin', '2020-01-03 17:13:10.607881', NULL, 'admin', 'Sample', '样本', NULL, 't', 't', NULL, NULL);
INSERT INTO "public"."material_category" VALUES (11, '2020-02-11 18:00:53.154844', NULL, 'admin', '2020-02-11 18:00:53.154845', NULL, 'admin', 'AA', 'AA', NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for material_category_config
-- ----------------------------
DROP TABLE IF EXISTS "public"."material_category_config";
CREATE TABLE "public"."material_category_config" (
  "id" int4 NOT NULL DEFAULT nextval('material_category_config_id_seq'::regclass),
  "material_category_id" int4,
  "config_key" text COLLATE "pg_catalog"."default",
  "config_key_desc" text COLLATE "pg_catalog"."default",
  "config_value_type" text COLLATE "pg_catalog"."default",
  "config_default_value" text COLLATE "pg_catalog"."default",
  "required" bool,
  "remark" text COLLATE "pg_catalog"."default",
  "sort" int4
)
;

-- ----------------------------
-- Records of material_category_config
-- ----------------------------
INSERT INTO "public"."material_category_config" VALUES (2, 1, 'RackWidth', '料架宽(mm)', '20', NULL, 't', NULL, 20);
INSERT INTO "public"."material_category_config" VALUES (3, 1, 'RackHeight', '料架高(mm)', '20', NULL, 't', NULL, 30);
INSERT INTO "public"."material_category_config" VALUES (4, 1, 'RackBarcodeHeight', '料架贴码高度(mm)', '20', NULL, 't', NULL, 40);
INSERT INTO "public"."material_category_config" VALUES (5, 1, 'LevelCounts', '层数', '20', NULL, 't', NULL, 50);
INSERT INTO "public"."material_category_config" VALUES (6, 1, 'LevelLength', '层长(mm)', '20', NULL, 't', NULL, 60);
INSERT INTO "public"."material_category_config" VALUES (7, 1, 'LevelWidth', '层宽(mm)', '20', NULL, 't', NULL, 70);
INSERT INTO "public"."material_category_config" VALUES (8, 1, 'LevelHeight', '层高(mm)', '20', NULL, 't', NULL, 80);
INSERT INTO "public"."material_category_config" VALUES (9, 1, 'LevelBarcodeHeight', '层贴码高度(mm)', '20', NULL, 't', NULL, 90);
INSERT INTO "public"."material_category_config" VALUES (29, 4, 'Length', '长(mm)', '20', NULL, 't', NULL, 10);
INSERT INTO "public"."material_category_config" VALUES (30, 4, 'Width', '宽(mm)', '20', NULL, 't', NULL, 20);
INSERT INTO "public"."material_category_config" VALUES (31, 4, 'Height', '高(mm)', '20', NULL, 't', NULL, 30);
INSERT INTO "public"."material_category_config" VALUES (32, 4, 'RowCounts', '行数', '20', NULL, 't', NULL, 40);
INSERT INTO "public"."material_category_config" VALUES (33, 4, 'ColCounts', '列数', '20', NULL, 't', NULL, 50);
INSERT INTO "public"."material_category_config" VALUES (34, 4, 'RowSpace', '行间距(mm)', '20', NULL, 't', NULL, 60);
INSERT INTO "public"."material_category_config" VALUES (35, 4, 'ColSpace', '列间距(mm)', '20', NULL, 't', NULL, 70);
INSERT INTO "public"."material_category_config" VALUES (36, 4, 'ConsBottomOfZ', '底部Z(mm)', '20', NULL, 't', NULL, 80);
INSERT INTO "public"."material_category_config" VALUES (37, 4, 'GraspOffsetOfZ', '抓取偏移Z(mm)', '20', NULL, 't', NULL, 90);
INSERT INTO "public"."material_category_config" VALUES (38, 4, 'GraspOffsetOfG', '抓取偏移G(mm)', '20', NULL, 't', NULL, 100);
INSERT INTO "public"."material_category_config" VALUES (39, 4, 'GraspOffsetOfEpson', '主机械臂夹爪偏移Z(mm)', '20', NULL, 't', NULL, 110);
INSERT INTO "public"."material_category_config" VALUES (43, 7, 'Property', '性质', '10', NULL, 't', NULL, 10);
INSERT INTO "public"."material_category_config" VALUES (44, 7, 'Storage', '存储条件', '20', NULL, 't', NULL, 20);
INSERT INTO "public"."material_category_config" VALUES (45, 8, 'Length', '长(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (46, 8, 'Width', '宽(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (47, 8, 'Height', '高(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (48, 8, 'GraspOffsetOfZ', '抓取偏移Z(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (49, 8, 'GraspOffsetOfG', '抓取偏移G(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (51, 9, 'Width', '宽(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (52, 9, 'Height', '高(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (53, 9, 'GraspOffsetOfZ', '抓取偏移Z(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (54, 9, 'GraspOffsetOfG', '抓取偏移G(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (55, 9, 'GraspOffsetOfEpson', '主机械臂夹爪偏移Z(mm)', '20', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (50, 9, 'Length', '长(mm)', '10', NULL, 't', NULL, NULL);
INSERT INTO "public"."material_category_config" VALUES (1, 1, 'RackLength', '料架长(mm)', '20', NULL, 't', NULL, 10);
INSERT INTO "public"."material_category_config" VALUES (57, 3, 'Length', '长(mm)', '20', NULL, 't', NULL, 10);
INSERT INTO "public"."material_category_config" VALUES (58, 3, 'Width', '宽(mm)', '20', NULL, 't', NULL, 20);
INSERT INTO "public"."material_category_config" VALUES (59, 3, 'Height', '高(mm)', '20', NULL, 't', NULL, 30);
INSERT INTO "public"."material_category_config" VALUES (60, 3, 'RowCounts', '行数', '20', NULL, 't', NULL, 40);
INSERT INTO "public"."material_category_config" VALUES (61, 3, 'ColCounts', '列数', '20', NULL, 't', NULL, 50);
INSERT INTO "public"."material_category_config" VALUES (62, 3, 'RowSpace', '行间距(mm)', '20', NULL, 't', NULL, 60);
INSERT INTO "public"."material_category_config" VALUES (63, 3, 'ColSpace', '列间距(mm)', '20', NULL, 't', NULL, 70);
INSERT INTO "public"."material_category_config" VALUES (64, 3, 'ConsBottomOfZ', '底部Z(mm)', '20', NULL, 't', NULL, 80);
INSERT INTO "public"."material_category_config" VALUES (65, 3, 'GraspOffsetOfZ', '抓取偏移Z(mm)', '20', NULL, 't', NULL, 90);
INSERT INTO "public"."material_category_config" VALUES (66, 3, 'GraspOffsetOfG', '抓取偏移G(mm)', '20', NULL, 't', NULL, 100);
INSERT INTO "public"."material_category_config" VALUES (67, 3, 'GraspOffsetOfEpson', '主机械臂夹爪偏移Z(mm)', '20', NULL, 't', NULL, 110);
INSERT INTO "public"."material_category_config" VALUES (68, 3, 'FilmType', '膜类型', '10', NULL, 't', NULL, 120);
INSERT INTO "public"."material_category_config" VALUES (69, 3, 'PlateLocTemp', '封膜温度(℃)', '20', NULL, 't', '范围：20-235', 130);
INSERT INTO "public"."material_category_config" VALUES (70, 3, 'PlateLocDuration', '封膜时长(s)', '20', NULL, 't', '范围：0.5-12，最多精确到小数点后一位', 140);
INSERT INTO "public"."material_category_config" VALUES (71, 3, 'AdhereTime', '粘附时长', '20', NULL, 't', '参数为1-4  1 = 2.5s  2 = 5s  3 = 7.5s  4 = 10s', 150);
INSERT INTO "public"."material_category_config" VALUES (72, 3, 'LocationSpeed', '位置速度', '20', NULL, 't', '参数为1-9  1 = Begin Peel Location:Default -2mm; Speed:fast  2 = Begin Peel Location:Default -2mm; Speed:slow  3 = Begin Peel Location:Default; Speed:fast  4 = Begin Peel Location:Default; Speed:slow  5 = Begin Peel Location:Default +2mm; Speed:fast  6 = Begin Peel Location:Default +2mm; Speed:slow  7 ', 160);
INSERT INTO "public"."material_category_config" VALUES (73, 5, 'Storage', '存储条件', '20', NULL, 't', NULL, 10);
INSERT INTO "public"."material_category_config" VALUES (74, 5, 'CentriVel', '离心速率(%)', '20', NULL, 't', NULL, 20);
INSERT INTO "public"."material_category_config" VALUES (75, 5, 'CentriAccel', '离心加速度(%)', '20', NULL, 't', NULL, 30);
INSERT INTO "public"."material_category_config" VALUES (76, 5, 'CentriDecel', '离心减速度(%)', '20', NULL, 't', NULL, 40);
INSERT INTO "public"."material_category_config" VALUES (77, 5, 'CentriDuration', '离心时长(s)', '20', NULL, 't', NULL, 50);
INSERT INTO "public"."material_category_config" VALUES (78, 5, 'BalancedPlatePN', '配平板货号', '10', NULL, 't', NULL, 60);
INSERT INTO "public"."material_category_config" VALUES (79, 10, 'Length', '长(mm)', '20', NULL, 't', NULL, 10);
INSERT INTO "public"."material_category_config" VALUES (80, 10, 'Width', '宽(mm)', '20', NULL, 't', NULL, 20);
INSERT INTO "public"."material_category_config" VALUES (81, 10, 'Height', '高(mm)', '20', NULL, 't', NULL, 30);
INSERT INTO "public"."material_category_config" VALUES (82, 10, 'Weight', '重量(g)', '20', NULL, 't', NULL, 40);
INSERT INTO "public"."material_category_config" VALUES (83, 10, 'GraspOffsetOfEpson', '主机械臂夹爪偏移Z(mm)', '20', NULL, 't', NULL, 50);
INSERT INTO "public"."material_category_config" VALUES (91, 6, 'Property', '性质', '10', NULL, 't', NULL, 10);
INSERT INTO "public"."material_category_config" VALUES (92, 6, 'Storage', '存储条件', '20', NULL, 't', NULL, 20);
INSERT INTO "public"."material_category_config" VALUES (93, 6, 'CentriVel', '离心速率(%)', '20', NULL, 't', NULL, 30);
INSERT INTO "public"."material_category_config" VALUES (94, 6, 'CentriAccel', '离心加速度(%)', '20', NULL, 't', NULL, 40);
INSERT INTO "public"."material_category_config" VALUES (95, 6, 'CentriDecel', '离心减速度(%)', '20', NULL, 't', NULL, 50);
INSERT INTO "public"."material_category_config" VALUES (96, 6, 'CentriDuration', '离心时长(s)', '20', NULL, 't', NULL, 60);
INSERT INTO "public"."material_category_config" VALUES (97, 6, 'BalancedPlatePN', '配平板货号', '10', NULL, 't', NULL, 70);

-- ----------------------------
-- Table structure for material_config
-- ----------------------------
DROP TABLE IF EXISTS "public"."material_config";
CREATE TABLE "public"."material_config" (
  "id" int4 NOT NULL DEFAULT nextval('material_config_id_seq'::regclass),
  "material_id" int4,
  "config_key" text COLLATE "pg_catalog"."default",
  "config_value" text COLLATE "pg_catalog"."default",
  "sort" int4
)
;

-- ----------------------------
-- Records of material_config
-- ----------------------------
INSERT INTO "public"."material_config" VALUES (1968, 37, 'CentriTemp', '0', NULL);
INSERT INTO "public"."material_config" VALUES (1969, 37, 'LocationSpeed', '0', 160);
INSERT INTO "public"."material_config" VALUES (1970, 37, 'AdhereTime', '0', 150);
INSERT INTO "public"."material_config" VALUES (1971, 37, 'PlateLocDuration', '0', 140);
INSERT INTO "public"."material_config" VALUES (1972, 37, 'PlateLocTemp', '0', 130);
INSERT INTO "public"."material_config" VALUES (125, 12, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (2176, 79, 'RackLength', '0', 10);
INSERT INTO "public"."material_config" VALUES (127, 14, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (128, 15, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (129, 16, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (130, 17, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (131, 18, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (132, 19, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (133, 20, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (134, 21, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (135, 22, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (136, 23, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (137, 24, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (138, 25, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (139, 26, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (140, 27, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (141, 28, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (142, 29, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (143, 30, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (144, 31, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (145, 32, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (146, 33, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (147, 34, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (2177, 79, 'RackWidth', '0', 20);
INSERT INTO "public"."material_config" VALUES (2178, 79, 'RackHeight', '0', 30);
INSERT INTO "public"."material_config" VALUES (2179, 79, 'RackBarcodeHeight', '0', 40);
INSERT INTO "public"."material_config" VALUES (2180, 79, 'LevelCounts', '10', 50);
INSERT INTO "public"."material_config" VALUES (2181, 79, 'LevelLength', '0', 60);
INSERT INTO "public"."material_config" VALUES (2182, 79, 'LevelWidth', '0', 70);
INSERT INTO "public"."material_config" VALUES (2183, 79, 'LevelHeight', '0', 80);
INSERT INTO "public"."material_config" VALUES (2184, 79, 'LevelBarcodeHeight', '0', 90);
INSERT INTO "public"."material_config" VALUES (2185, 80, 'RackLength', '0', 10);
INSERT INTO "public"."material_config" VALUES (2186, 80, 'RackWidth', '0', 20);
INSERT INTO "public"."material_config" VALUES (2187, 80, 'RackHeight', '0', 30);
INSERT INTO "public"."material_config" VALUES (2188, 80, 'RackBarcodeHeight', '0', 40);
INSERT INTO "public"."material_config" VALUES (2189, 80, 'LevelCounts', '21', 50);
INSERT INTO "public"."material_config" VALUES (2190, 80, 'LevelLength', '0', 60);
INSERT INTO "public"."material_config" VALUES (2191, 80, 'LevelWidth', '0', 70);
INSERT INTO "public"."material_config" VALUES (2192, 80, 'LevelHeight', '0', 80);
INSERT INTO "public"."material_config" VALUES (2193, 80, 'LevelBarcodeHeight', '0', 90);
INSERT INTO "public"."material_config" VALUES (2311, 10, 'Length', '127', 10);
INSERT INTO "public"."material_config" VALUES (2312, 10, 'Width', '81.1', 20);
INSERT INTO "public"."material_config" VALUES (2313, 10, 'Height', '60', 30);
INSERT INTO "public"."material_config" VALUES (2314, 10, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (126, 13, 'Storage', NULL, 10);
INSERT INTO "public"."material_config" VALUES (419, 4, 'RackLength', '141', NULL);
INSERT INTO "public"."material_config" VALUES (420, 4, 'RackWidth', '99', NULL);
INSERT INTO "public"."material_config" VALUES (421, 4, 'RackHeight', '620.1', NULL);
INSERT INTO "public"."material_config" VALUES (422, 4, 'RackBarcodeHeight', '578.5', NULL);
INSERT INTO "public"."material_config" VALUES (423, 4, 'LevelCounts', '13', NULL);
INSERT INTO "public"."material_config" VALUES (424, 4, 'LevelLength', '129', NULL);
INSERT INTO "public"."material_config" VALUES (425, 4, 'LevelWidth', '87', NULL);
INSERT INTO "public"."material_config" VALUES (426, 4, 'LevelHeight', '45', NULL);
INSERT INTO "public"."material_config" VALUES (427, 4, 'LevelBarcodeHeight', '0', NULL);
INSERT INTO "public"."material_config" VALUES (1973, 37, 'FilmType', '', 120);
INSERT INTO "public"."material_config" VALUES (1974, 37, 'GraspOffsetOfEpson', '2', 110);
INSERT INTO "public"."material_config" VALUES (1975, 37, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (1976, 37, 'CentriSpeed', '0', 170);
INSERT INTO "public"."material_config" VALUES (1977, 37, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (1978, 37, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (1979, 37, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (1980, 37, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (1981, 37, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (1982, 37, 'Height', '14.3', 30);
INSERT INTO "public"."material_config" VALUES (2315, 10, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2316, 10, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2317, 10, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2318, 10, 'ConsBottomOfZ', '5', 80);
INSERT INTO "public"."material_config" VALUES (2319, 10, 'GraspOffsetOfZ', '37.5', 90);
INSERT INTO "public"."material_config" VALUES (2320, 10, 'GraspOffsetOfG', '0.9', 100);
INSERT INTO "public"."material_config" VALUES (2321, 10, 'GraspOffsetOfEpson', '14.5', 110);
INSERT INTO "public"."material_config" VALUES (2604, 73, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2605, 73, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2606, 73, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2607, 73, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2608, 73, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2609, 73, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2610, 74, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2611, 74, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2232, 44, 'Width', '85.5', NULL);
INSERT INTO "public"."material_config" VALUES (2233, 44, 'Height', '20.1', NULL);
INSERT INTO "public"."material_config" VALUES (2234, 44, 'GraspOffsetOfZ', '6.7', NULL);
INSERT INTO "public"."material_config" VALUES (410, 3, 'RackLength', '141', NULL);
INSERT INTO "public"."material_config" VALUES (411, 3, 'RackWidth', '99', NULL);
INSERT INTO "public"."material_config" VALUES (412, 3, 'RackHeight', '620.1', NULL);
INSERT INTO "public"."material_config" VALUES (413, 3, 'RackBarcodeHeight', '578.5', NULL);
INSERT INTO "public"."material_config" VALUES (414, 3, 'LevelCounts', '7', NULL);
INSERT INTO "public"."material_config" VALUES (415, 3, 'LevelLength', '129', NULL);
INSERT INTO "public"."material_config" VALUES (416, 3, 'LevelWidth', '87', NULL);
INSERT INTO "public"."material_config" VALUES (417, 3, 'LevelHeight', '80', NULL);
INSERT INTO "public"."material_config" VALUES (418, 3, 'LevelBarcodeHeight', '0', NULL);
INSERT INTO "public"."material_config" VALUES (2235, 44, 'GraspOffsetOfG', '0.8', NULL);
INSERT INTO "public"."material_config" VALUES (2236, 44, 'GraspOffsetOfEpson', '-1.5', NULL);
INSERT INTO "public"."material_config" VALUES (2237, 44, 'Length', '127.7', NULL);
INSERT INTO "public"."material_config" VALUES (2612, 74, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2243, 43, 'Length', '126.8', NULL);
INSERT INTO "public"."material_config" VALUES (2244, 43, 'Width', '84.4', NULL);
INSERT INTO "public"."material_config" VALUES (2245, 43, 'Height', '7', NULL);
INSERT INTO "public"."material_config" VALUES (2246, 43, 'GraspOffsetOfZ', '-2.5', NULL);
INSERT INTO "public"."material_config" VALUES (2247, 43, 'GraspOffsetOfG', '1', NULL);
INSERT INTO "public"."material_config" VALUES (2373, 82, 'Length', '124.5', NULL);
INSERT INTO "public"."material_config" VALUES (2374, 82, 'Width', '81.2', NULL);
INSERT INTO "public"."material_config" VALUES (2375, 82, 'Height', '14.3', NULL);
INSERT INTO "public"."material_config" VALUES (2376, 82, 'Weight', '63', NULL);
INSERT INTO "public"."material_config" VALUES (2377, 82, 'GraspOffsetOfEpson', '2', NULL);
INSERT INTO "public"."material_config" VALUES (2613, 74, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2614, 74, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2615, 74, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2616, 75, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2617, 75, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2618, 75, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2619, 75, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2620, 75, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2621, 75, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2622, 76, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (848, 5, 'RackLength', '141', NULL);
INSERT INTO "public"."material_config" VALUES (849, 5, 'RackWidth', '99', NULL);
INSERT INTO "public"."material_config" VALUES (850, 5, 'RackHeight', '620.1', NULL);
INSERT INTO "public"."material_config" VALUES (851, 5, 'RackBarcodeHeight', '578.5', NULL);
INSERT INTO "public"."material_config" VALUES (852, 5, 'LevelCounts', '18', NULL);
INSERT INTO "public"."material_config" VALUES (853, 5, 'LevelLength', '129', NULL);
INSERT INTO "public"."material_config" VALUES (854, 5, 'LevelWidth', '87', NULL);
INSERT INTO "public"."material_config" VALUES (855, 5, 'LevelHeight', '32', NULL);
INSERT INTO "public"."material_config" VALUES (856, 5, 'LevelBarcodeHeight', '0', NULL);
INSERT INTO "public"."material_config" VALUES (1983, 37, 'Width', '81.2', 20);
INSERT INTO "public"."material_config" VALUES (1984, 37, 'Length', '124.5', 10);
INSERT INTO "public"."material_config" VALUES (1985, 37, 'ConsBottomOfZ', '3', 80);
INSERT INTO "public"."material_config" VALUES (1986, 37, 'CentriDuration', '0', 180);
INSERT INTO "public"."material_config" VALUES (2623, 76, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2624, 76, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2625, 76, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2626, 76, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2627, 76, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2077, 47, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2078, 47, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2079, 47, 'Height', '66.5', 30);
INSERT INTO "public"."material_config" VALUES (2080, 47, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2081, 47, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2082, 47, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2083, 47, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2084, 47, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2085, 47, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2086, 47, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2087, 47, 'GraspOffsetOfEpson', '26', 110);
INSERT INTO "public"."material_config" VALUES (2088, 48, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2089, 48, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2090, 48, 'Height', '66.5', 30);
INSERT INTO "public"."material_config" VALUES (2091, 48, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2092, 48, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2093, 48, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2094, 48, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2095, 48, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2322, 11, 'Length', '127', 10);
INSERT INTO "public"."material_config" VALUES (2323, 11, 'Width', '81.1', 20);
INSERT INTO "public"."material_config" VALUES (2096, 48, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2097, 48, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2098, 48, 'GraspOffsetOfEpson', '26', 110);
INSERT INTO "public"."material_config" VALUES (2132, 52, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2133, 52, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2324, 11, 'Height', '60', 30);
INSERT INTO "public"."material_config" VALUES (2325, 11, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2326, 11, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2327, 11, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2328, 11, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2329, 11, 'ConsBottomOfZ', '5', 80);
INSERT INTO "public"."material_config" VALUES (2330, 11, 'GraspOffsetOfZ', '37.5', 90);
INSERT INTO "public"."material_config" VALUES (2331, 11, 'GraspOffsetOfG', '0.9', 100);
INSERT INTO "public"."material_config" VALUES (2332, 11, 'GraspOffsetOfEpson', '14.5', 110);
INSERT INTO "public"."material_config" VALUES (2378, 83, 'Length', '123', NULL);
INSERT INTO "public"."material_config" VALUES (2379, 83, 'Width', '82.2', NULL);
INSERT INTO "public"."material_config" VALUES (2380, 83, 'Height', '16', NULL);
INSERT INTO "public"."material_config" VALUES (2381, 83, 'Weight', '40', NULL);
INSERT INTO "public"."material_config" VALUES (2382, 83, 'GraspOffsetOfEpson', '0', NULL);
INSERT INTO "public"."material_config" VALUES (2248, 56, 'CentriTemp', '0', NULL);
INSERT INTO "public"."material_config" VALUES (2249, 56, 'LocationSpeed', '1', 160);
INSERT INTO "public"."material_config" VALUES (2250, 56, 'AdhereTime', '1', 150);
INSERT INTO "public"."material_config" VALUES (2251, 56, 'PlateLocDuration', '2', 140);
INSERT INTO "public"."material_config" VALUES (2252, 56, 'PlateLocTemp', '175', 130);
INSERT INTO "public"."material_config" VALUES (2253, 56, 'FilmType', '非穿刺膜', 120);
INSERT INTO "public"."material_config" VALUES (2134, 52, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2135, 52, 'Height', '104.5', 30);
INSERT INTO "public"."material_config" VALUES (2136, 52, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2137, 52, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2138, 52, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2139, 52, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2254, 56, 'GraspOffsetOfEpson', '3', 110);
INSERT INTO "public"."material_config" VALUES (2255, 56, 'GraspOffsetOfG', '0.8', 100);
INSERT INTO "public"."material_config" VALUES (2256, 56, 'CentriSpeed', '0', 170);
INSERT INTO "public"."material_config" VALUES (2257, 56, 'GraspOffsetOfZ', '14', 90);
INSERT INTO "public"."material_config" VALUES (2258, 56, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2259, 56, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2260, 56, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2261, 56, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2262, 56, 'Height', '32', 30);
INSERT INTO "public"."material_config" VALUES (2263, 56, 'Width', '80.8', 20);
INSERT INTO "public"."material_config" VALUES (2264, 56, 'Length', '123', 10);
INSERT INTO "public"."material_config" VALUES (2265, 56, 'ConsBottomOfZ', '2.7', 80);
INSERT INTO "public"."material_config" VALUES (2266, 56, 'CentriDuration', '0', 180);
INSERT INTO "public"."material_config" VALUES (2140, 52, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2141, 52, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2142, 52, 'GraspOffsetOfEpson', '63.5', 110);
INSERT INTO "public"."material_config" VALUES (2154, 54, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2155, 54, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2156, 54, 'Height', '66.5', 30);
INSERT INTO "public"."material_config" VALUES (2157, 54, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2158, 54, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2159, 54, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2160, 54, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2161, 54, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2162, 54, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2163, 54, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2164, 54, 'GraspOffsetOfEpson', '26', 110);
INSERT INTO "public"."material_config" VALUES (1652, 35, 'Property', '', NULL);
INSERT INTO "public"."material_config" VALUES (1653, 35, 'Storage', '0', NULL);
INSERT INTO "public"."material_config" VALUES (2514, 58, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2628, 77, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2629, 77, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2630, 77, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2631, 77, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2333, 40, 'Length', '127', 10);
INSERT INTO "public"."material_config" VALUES (2334, 40, 'Width', '81.1', 20);
INSERT INTO "public"."material_config" VALUES (2335, 40, 'Height', '60', 30);
INSERT INTO "public"."material_config" VALUES (2336, 40, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2337, 40, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2338, 40, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2339, 40, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2340, 40, 'ConsBottomOfZ', '5', 80);
INSERT INTO "public"."material_config" VALUES (2341, 40, 'GraspOffsetOfZ', '37.5', 90);
INSERT INTO "public"."material_config" VALUES (2342, 40, 'GraspOffsetOfG', '0.9', 100);
INSERT INTO "public"."material_config" VALUES (2343, 40, 'GraspOffsetOfEpson', '14.5', 110);
INSERT INTO "public"."material_config" VALUES (2344, 41, 'Length', '127', 10);
INSERT INTO "public"."material_config" VALUES (2345, 41, 'Width', '81.1', 20);
INSERT INTO "public"."material_config" VALUES (2346, 41, 'Height', '60', 30);
INSERT INTO "public"."material_config" VALUES (2347, 41, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2348, 41, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2349, 41, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2350, 41, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2351, 41, 'ConsBottomOfZ', '5', 80);
INSERT INTO "public"."material_config" VALUES (2352, 41, 'GraspOffsetOfZ', '37.5', 90);
INSERT INTO "public"."material_config" VALUES (2353, 41, 'GraspOffsetOfG', '0.9', 100);
INSERT INTO "public"."material_config" VALUES (2632, 77, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2633, 77, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2634, 78, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2635, 78, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2636, 78, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2354, 41, 'GraspOffsetOfEpson', '14.5', 110);
INSERT INTO "public"."material_config" VALUES (2383, 84, 'Length', '123', NULL);
INSERT INTO "public"."material_config" VALUES (2384, 84, 'Width', '80.8', NULL);
INSERT INTO "public"."material_config" VALUES (2385, 84, 'Height', '32', NULL);
INSERT INTO "public"."material_config" VALUES (2386, 84, 'Weight', '80', NULL);
INSERT INTO "public"."material_config" VALUES (2387, 84, 'GraspOffsetOfEpson', '3', NULL);
INSERT INTO "public"."material_config" VALUES (2637, 78, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2638, 78, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2639, 78, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2044, 42, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2045, 42, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2046, 42, 'Height', '66.5', 30);
INSERT INTO "public"."material_config" VALUES (2047, 42, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2048, 42, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2049, 42, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2050, 42, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2051, 42, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2052, 42, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2053, 42, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2054, 42, 'GraspOffsetOfEpson', '26', 110);
INSERT INTO "public"."material_config" VALUES (2066, 46, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2067, 46, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2068, 46, 'Height', '104.5', 30);
INSERT INTO "public"."material_config" VALUES (2069, 46, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2070, 46, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2071, 46, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2072, 46, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2073, 46, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2074, 46, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2075, 46, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2076, 46, 'GraspOffsetOfEpson', '63.5', 110);
INSERT INTO "public"."material_config" VALUES (2099, 49, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2100, 49, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2101, 49, 'Height', '104.5', 30);
INSERT INTO "public"."material_config" VALUES (2102, 49, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2103, 49, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2104, 49, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2105, 49, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2106, 49, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2107, 49, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2108, 49, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2109, 49, 'GraspOffsetOfEpson', '63.5', 110);
INSERT INTO "public"."material_config" VALUES (2110, 50, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2111, 50, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2112, 50, 'Height', '66.5', 30);
INSERT INTO "public"."material_config" VALUES (2113, 50, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2114, 50, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2115, 50, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2116, 50, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2117, 50, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2118, 50, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2119, 50, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2120, 50, 'GraspOffsetOfEpson', '26', 110);
INSERT INTO "public"."material_config" VALUES (2121, 51, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2122, 51, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (1867, 9, 'CentriTemp', '0', NULL);
INSERT INTO "public"."material_config" VALUES (1868, 9, 'LocationSpeed', '1', 160);
INSERT INTO "public"."material_config" VALUES (1869, 9, 'AdhereTime', '1', 150);
INSERT INTO "public"."material_config" VALUES (1870, 9, 'PlateLocDuration', '2', 140);
INSERT INTO "public"."material_config" VALUES (1871, 9, 'PlateLocTemp', '175', 130);
INSERT INTO "public"."material_config" VALUES (1872, 9, 'FilmType', '非穿刺膜', 120);
INSERT INTO "public"."material_config" VALUES (1873, 9, 'GraspOffsetOfEpson', '0', 110);
INSERT INTO "public"."material_config" VALUES (1874, 9, 'GraspOffsetOfG', '1', 100);
INSERT INTO "public"."material_config" VALUES (1875, 9, 'CentriSpeed', '0', 170);
INSERT INTO "public"."material_config" VALUES (1876, 9, 'GraspOffsetOfZ', '8', 90);
INSERT INTO "public"."material_config" VALUES (1877, 9, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (1878, 9, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (1879, 9, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (1880, 9, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (1881, 9, 'Height', '16', 30);
INSERT INTO "public"."material_config" VALUES (1882, 9, 'Width', '82.2', 20);
INSERT INTO "public"."material_config" VALUES (1883, 9, 'Length', '123', 10);
INSERT INTO "public"."material_config" VALUES (1884, 9, 'ConsBottomOfZ', '1.7', 80);
INSERT INTO "public"."material_config" VALUES (1885, 9, 'CentriDuration', '0', 180);
INSERT INTO "public"."material_config" VALUES (2640, 2, 'RackLength', '141', 10);
INSERT INTO "public"."material_config" VALUES (2641, 2, 'RackWidth', '99', 20);
INSERT INTO "public"."material_config" VALUES (2642, 2, 'RackHeight', '620.1', 30);
INSERT INTO "public"."material_config" VALUES (2643, 2, 'RackBarcodeHeight', '578.5', 40);
INSERT INTO "public"."material_config" VALUES (2644, 2, 'LevelCounts', '4', 50);
INSERT INTO "public"."material_config" VALUES (2645, 2, 'LevelLength', '129', 60);
INSERT INTO "public"."material_config" VALUES (2646, 2, 'LevelWidth', '87', 70);
INSERT INTO "public"."material_config" VALUES (2647, 2, 'LevelHeight', '125', 80);
INSERT INTO "public"."material_config" VALUES (2648, 2, 'LevelBarcodeHeight', '91', 90);
INSERT INTO "public"."material_config" VALUES (1905, 57, 'LocationSpeed', '1', 160);
INSERT INTO "public"."material_config" VALUES (1906, 57, 'AdhereTime', '1', 150);
INSERT INTO "public"."material_config" VALUES (1907, 57, 'PlateLocDuration', '2', 140);
INSERT INTO "public"."material_config" VALUES (1908, 57, 'PlateLocTemp', '175', 130);
INSERT INTO "public"."material_config" VALUES (1909, 57, 'FilmType', '非穿刺膜', 120);
INSERT INTO "public"."material_config" VALUES (1910, 57, 'GraspOffsetOfEpson', '0', 110);
INSERT INTO "public"."material_config" VALUES (1911, 57, 'GraspOffsetOfG', '1', 100);
INSERT INTO "public"."material_config" VALUES (1912, 57, 'GraspOffsetOfZ', '8', 90);
INSERT INTO "public"."material_config" VALUES (1913, 57, 'CentriTemp', '0', NULL);
INSERT INTO "public"."material_config" VALUES (1914, 57, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (1915, 57, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (1916, 57, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (1917, 57, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (1918, 57, 'Height', '16', 30);
INSERT INTO "public"."material_config" VALUES (1919, 57, 'Width', '82.2', 20);
INSERT INTO "public"."material_config" VALUES (1920, 57, 'Length', '123', 10);
INSERT INTO "public"."material_config" VALUES (1921, 57, 'CentriSpeed', '0', 170);
INSERT INTO "public"."material_config" VALUES (1922, 57, 'ConsBottomOfZ', '1.7', 80);
INSERT INTO "public"."material_config" VALUES (1923, 57, 'CentriDuration', '0', 180);
INSERT INTO "public"."material_config" VALUES (2055, 45, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2056, 45, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2057, 45, 'Height', '66.5', 30);
INSERT INTO "public"."material_config" VALUES (2058, 45, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2059, 45, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2060, 45, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2061, 45, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2062, 45, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2063, 45, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2064, 45, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2065, 45, 'GraspOffsetOfEpson', '26', 110);
INSERT INTO "public"."material_config" VALUES (2123, 51, 'Height', '66.5', 30);
INSERT INTO "public"."material_config" VALUES (2124, 51, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2125, 51, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2126, 51, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2127, 51, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2128, 51, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2129, 51, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2130, 51, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2131, 51, 'GraspOffsetOfEpson', '26', 110);
INSERT INTO "public"."material_config" VALUES (2143, 53, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2144, 53, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2145, 53, 'Height', '66.5', 30);
INSERT INTO "public"."material_config" VALUES (2146, 53, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2147, 53, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2148, 53, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2149, 53, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2150, 53, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2151, 53, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2152, 53, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2153, 53, 'GraspOffsetOfEpson', '26', 110);
INSERT INTO "public"."material_config" VALUES (2165, 55, 'Length', '127.8', 10);
INSERT INTO "public"."material_config" VALUES (2166, 55, 'Width', '85.6', 20);
INSERT INTO "public"."material_config" VALUES (2167, 55, 'Height', '104.5', 30);
INSERT INTO "public"."material_config" VALUES (2168, 55, 'RowCounts', '8', 40);
INSERT INTO "public"."material_config" VALUES (2169, 55, 'ColCounts', '12', 50);
INSERT INTO "public"."material_config" VALUES (2170, 55, 'RowSpace', '9', 60);
INSERT INTO "public"."material_config" VALUES (2171, 55, 'ColSpace', '9', 70);
INSERT INTO "public"."material_config" VALUES (2172, 55, 'ConsBottomOfZ', '0', 80);
INSERT INTO "public"."material_config" VALUES (2173, 55, 'GraspOffsetOfZ', '0', 90);
INSERT INTO "public"."material_config" VALUES (2174, 55, 'GraspOffsetOfG', '0', 100);
INSERT INTO "public"."material_config" VALUES (2175, 55, 'GraspOffsetOfEpson', '63.5', 110);
INSERT INTO "public"."material_config" VALUES (2515, 58, 'CentriVel', '45', 20);
INSERT INTO "public"."material_config" VALUES (2516, 58, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2517, 58, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2518, 58, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2519, 58, 'BalancedPlatePN', 'MGBP03', 60);
INSERT INTO "public"."material_config" VALUES (2520, 64, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2521, 64, 'CentriVel', '45', 20);
INSERT INTO "public"."material_config" VALUES (2522, 64, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2523, 64, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2524, 64, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2525, 64, 'BalancedPlatePN', 'MGBP03', 60);
INSERT INTO "public"."material_config" VALUES (2526, 65, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2527, 65, 'CentriVel', '45', 20);
INSERT INTO "public"."material_config" VALUES (2528, 65, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2529, 65, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2530, 65, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2531, 65, 'BalancedPlatePN', 'MGBP03', 60);
INSERT INTO "public"."material_config" VALUES (2532, 66, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2533, 66, 'CentriVel', '45', 20);
INSERT INTO "public"."material_config" VALUES (2534, 66, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2535, 66, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2536, 66, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2537, 66, 'BalancedPlatePN', 'MGBP03', 60);
INSERT INTO "public"."material_config" VALUES (2538, 67, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2539, 67, 'CentriVel', '45', 20);
INSERT INTO "public"."material_config" VALUES (2540, 67, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2541, 67, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2542, 67, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2543, 67, 'BalancedPlatePN', 'MGBP03', 60);
INSERT INTO "public"."material_config" VALUES (2544, 68, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2545, 68, 'CentriVel', '45', 20);
INSERT INTO "public"."material_config" VALUES (2546, 68, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2547, 68, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2548, 68, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2549, 68, 'BalancedPlatePN', 'MGBP03', 60);
INSERT INTO "public"."material_config" VALUES (2550, 69, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2551, 69, 'CentriVel', '45', 20);
INSERT INTO "public"."material_config" VALUES (2552, 69, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2553, 69, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2554, 69, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2555, 69, 'BalancedPlatePN', 'MGBP03', 60);
INSERT INTO "public"."material_config" VALUES (2556, 59, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2557, 59, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2558, 59, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2559, 59, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2560, 59, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2561, 59, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2562, 60, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2563, 60, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2564, 60, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2565, 60, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2566, 60, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2567, 60, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2586, 70, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2587, 70, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2588, 70, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2589, 70, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2590, 70, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2591, 70, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2592, 71, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2593, 71, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2594, 71, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2595, 71, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2596, 71, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2597, 71, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2658, 7, 'RackLength', '141', 10);
INSERT INTO "public"."material_config" VALUES (2659, 7, 'RackWidth', '99', 20);
INSERT INTO "public"."material_config" VALUES (2660, 7, 'RackHeight', '620.1', 30);
INSERT INTO "public"."material_config" VALUES (2661, 7, 'RackBarcodeHeight', '578.5', 40);
INSERT INTO "public"."material_config" VALUES (2662, 7, 'LevelCounts', '4', 50);
INSERT INTO "public"."material_config" VALUES (2663, 7, 'LevelLength', '129', 60);
INSERT INTO "public"."material_config" VALUES (2664, 7, 'LevelWidth', '87', 70);
INSERT INTO "public"."material_config" VALUES (2665, 7, 'LevelHeight', '125', 80);
INSERT INTO "public"."material_config" VALUES (2666, 7, 'LevelBarcodeHeight', '53', 90);
INSERT INTO "public"."material_config" VALUES (2683, 36, 'Property', NULL, 10);
INSERT INTO "public"."material_config" VALUES (2684, 36, 'Storage', '0', 20);
INSERT INTO "public"."material_config" VALUES (2685, 36, 'CentriVel', '50', 30);
INSERT INTO "public"."material_config" VALUES (2686, 36, 'CentriAccel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2687, 36, 'CentriDecel', '80', 50);
INSERT INTO "public"."material_config" VALUES (2688, 36, 'CentriDuration', '8', 60);
INSERT INTO "public"."material_config" VALUES (2689, 36, 'BalancedPlatePN', 'MGBP02', 70);
INSERT INTO "public"."material_config" VALUES (2568, 61, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2569, 61, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2570, 61, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2571, 61, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2572, 61, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2573, 61, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2574, 62, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2575, 62, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2576, 62, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2577, 62, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2578, 62, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2579, 62, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2580, 63, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2581, 63, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2582, 63, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2583, 63, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2584, 63, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2585, 63, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2598, 72, 'Storage', '0', 10);
INSERT INTO "public"."material_config" VALUES (2599, 72, 'CentriVel', '50', 20);
INSERT INTO "public"."material_config" VALUES (2600, 72, 'CentriAccel', '80', 30);
INSERT INTO "public"."material_config" VALUES (2601, 72, 'CentriDecel', '80', 40);
INSERT INTO "public"."material_config" VALUES (2602, 72, 'CentriDuration', '8', 50);
INSERT INTO "public"."material_config" VALUES (2603, 72, 'BalancedPlatePN', 'MGBP02', 60);
INSERT INTO "public"."material_config" VALUES (2667, 6, 'RackLength', '141', 10);
INSERT INTO "public"."material_config" VALUES (2668, 6, 'RackWidth', '99', 20);
INSERT INTO "public"."material_config" VALUES (2669, 6, 'RackHeight', '620.1', 30);
INSERT INTO "public"."material_config" VALUES (2670, 6, 'RackBarcodeHeight', '578.5', 40);
INSERT INTO "public"."material_config" VALUES (2671, 6, 'LevelCounts', '7', 50);
INSERT INTO "public"."material_config" VALUES (2672, 6, 'LevelLength', '129', 60);
INSERT INTO "public"."material_config" VALUES (2673, 6, 'LevelWidth', '87', 70);
INSERT INTO "public"."material_config" VALUES (2674, 6, 'LevelHeight', '80', 80);
INSERT INTO "public"."material_config" VALUES (2675, 6, 'LevelBarcodeHeight', '53', 90);

-- ----------------------------
-- Table structure for material_serial_no
-- ----------------------------
DROP TABLE IF EXISTS "public"."material_serial_no";
CREATE TABLE "public"."material_serial_no" (
  "id" int4 NOT NULL DEFAULT nextval('material_serial_no_id_seq'::regclass),
  "brand_code" text COLLATE "pg_catalog"."default",
  "type_code" text COLLATE "pg_catalog"."default",
  "serial_no" int4 NOT NULL
)
;

-- ----------------------------
-- Records of material_serial_no
-- ----------------------------
INSERT INTO "public"."material_serial_no" VALUES (4, 'BR', 'MW', 2);
INSERT INTO "public"."material_serial_no" VALUES (5, 'GE', 'TP', 3);
INSERT INTO "public"."material_serial_no" VALUES (6, 'BG', 'BD', 6);
INSERT INTO "public"."material_serial_no" VALUES (7, 'BG', 'TE', 4);
INSERT INTO "public"."material_serial_no" VALUES (8, 'BG', 'ET', 2);
INSERT INTO "public"."material_serial_no" VALUES (9, 'BG', 'LE', 2);
INSERT INTO "public"."material_serial_no" VALUES (10, 'BG', 'W1', 2);
INSERT INTO "public"."material_serial_no" VALUES (11, 'BG', 'W2', 2);
INSERT INTO "public"."material_serial_no" VALUES (12, 'BG', 'MX', 5);
INSERT INTO "public"."material_serial_no" VALUES (13, 'BG', 'BF', 4);
INSERT INTO "public"."material_serial_no" VALUES (14, 'BG', 'EZ', 3);
INSERT INTO "public"."material_serial_no" VALUES (15, 'BG', 'PM', 2);
INSERT INTO "public"."material_serial_no" VALUES (16, 'BG', 'BC', 2);
INSERT INTO "public"."material_serial_no" VALUES (17, 'ED', 'UV', 2);
INSERT INTO "public"."material_serial_no" VALUES (20, 'GE', 'TF', 3);
INSERT INTO "public"."material_serial_no" VALUES (21, 'MG', 'PL', 2);
INSERT INTO "public"."material_serial_no" VALUES (22, 'MG', 'PH', 2);
INSERT INTO "public"."material_serial_no" VALUES (18, 'CR', 'TP', 4);
INSERT INTO "public"."material_serial_no" VALUES (23, 'CR', 'TF', 4);
INSERT INTO "public"."material_serial_no" VALUES (19, 'CR', 'AP', 4);
INSERT INTO "public"."material_serial_no" VALUES (24, 'CR', 'AF', 4);
INSERT INTO "public"."material_serial_no" VALUES (3, 'DN', 'DW', 2);
INSERT INTO "public"."material_serial_no" VALUES (25, 'MG', 'AL', 2);
INSERT INTO "public"."material_serial_no" VALUES (26, 'MG', '06', 2);
INSERT INTO "public"."material_serial_no" VALUES (27, 'MG', '01', 8);
INSERT INTO "public"."material_serial_no" VALUES (28, 'MS', 'MW', 2);
INSERT INTO "public"."material_serial_no" VALUES (29, 'GB', 'TE', 2);
INSERT INTO "public"."material_serial_no" VALUES (30, 'GB', 'BF', 6);
INSERT INTO "public"."material_serial_no" VALUES (31, 'GB', 'ET', 2);
INSERT INTO "public"."material_serial_no" VALUES (32, 'GB', 'BD', 6);
INSERT INTO "public"."material_serial_no" VALUES (33, 'GB', 'EZ', 5);
INSERT INTO "public"."material_serial_no" VALUES (34, 'GB', 'BC', 2);
INSERT INTO "public"."material_serial_no" VALUES (36, 'GB', 'MX', 2);
INSERT INTO "public"."material_serial_no" VALUES (37, 'GB', 'WT', 2);
INSERT INTO "public"."material_serial_no" VALUES (35, 'GB', 'PM', 3);
INSERT INTO "public"."material_serial_no" VALUES (38, 'TM', 'RK', 3);
INSERT INTO "public"."material_serial_no" VALUES (39, 'MG', 'BP', 4);
INSERT INTO "public"."material_serial_no" VALUES (2, 'MG', 'RK', 9);

-- ----------------------------
-- Table structure for material_type
-- ----------------------------
DROP TABLE IF EXISTS "public"."material_type";
CREATE TABLE "public"."material_type" (
  "id" int4 NOT NULL DEFAULT nextval('material_type_id_seq'::regclass),
  "create_time" timestamp(6),
  "create_user_id" int4,
  "create_user_name" text COLLATE "pg_catalog"."default",
  "modify_time" timestamp(6),
  "modify_user_id" int4,
  "modify_user_name" text COLLATE "pg_catalog"."default",
  "code" text COLLATE "pg_catalog"."default",
  "name" text COLLATE "pg_catalog"."default",
  "en_name" text COLLATE "pg_catalog"."default",
  "desc" text COLLATE "pg_catalog"."default",
  "category_id" int4,
  "category_name" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of material_type
-- ----------------------------
INSERT INTO "public"."material_type" VALUES (5, '2019-07-06 21:16:59.698071', NULL, 'admin', '2019-07-06 21:16:59.698072', NULL, 'admin', 'UV', '酶标板', NULL, NULL, 3, '耗材');
INSERT INTO "public"."material_type" VALUES (16, '2019-07-06 21:21:26.570099', NULL, 'admin', '2019-07-06 21:21:26.5701', NULL, 'admin', 'LE', '裂解液', NULL, NULL, 5, '试剂');
INSERT INTO "public"."material_type" VALUES (3, '2019-07-06 21:08:28.321191', NULL, 'admin', '2019-07-06 21:25:52.151115', NULL, 'admin', 'DW', '深孔板', NULL, 'DeepwellPlate', 3, '耗材');
INSERT INTO "public"."material_type" VALUES (4, '2019-07-06 21:08:57.196088', NULL, 'admin', '2019-07-06 21:25:59.15688', NULL, 'admin', 'MW', 'PCR板', NULL, 'MicrowellPlate', 3, '耗材');
INSERT INTO "public"."material_type" VALUES (7, '2019-07-06 21:19:21.695924', NULL, 'admin', '2019-07-06 21:26:37.578133', NULL, 'admin', 'BF', '缓冲液', NULL, 'Buffer', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (8, '2019-07-06 21:19:39.46261', NULL, 'admin', '2019-07-06 21:26:43.828868', NULL, 'admin', 'SD', '标准品', NULL, 'Standard', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (9, '2019-07-06 21:19:53.392019', NULL, 'admin', '2019-07-06 21:26:50.228826', NULL, 'admin', 'ET', '乙醇', NULL, 'Ethonal', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (10, '2019-07-06 21:20:04.676472', NULL, 'admin', '2019-07-06 21:26:55.980255', NULL, 'admin', 'BD', '磁珠', NULL, 'Beads', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (11, '2019-07-06 21:20:21.511614', NULL, 'admin', '2019-07-06 21:27:00.452171', NULL, 'admin', 'EZ', '酶', NULL, 'Enzyme', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (12, '2019-07-06 21:20:33.720128', NULL, 'admin', '2019-07-06 21:27:05.373573', NULL, 'admin', 'MX', '混合液', NULL, 'Mix', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (13, '2019-07-06 21:20:46.488353', NULL, 'admin', '2019-07-06 21:27:15.919066', NULL, 'admin', 'PM', '引物', NULL, 'Primer', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (14, '2019-07-06 21:21:06.608917', NULL, 'admin', '2019-07-06 21:27:20.982391', NULL, 'admin', 'WT', '水', NULL, 'Water', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (15, '2019-07-06 21:21:16.344378', NULL, 'admin', '2019-07-06 21:27:26.116757', NULL, 'admin', 'BC', '接头', NULL, 'BarcodeAdaptor', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (18, '2019-07-06 21:23:18.45646', NULL, 'admin', '2019-07-06 21:27:45.636399', NULL, 'admin', 'W2', '清洗液2', NULL, 'Wash2', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (19, '2019-07-06 21:23:29.018283', NULL, 'admin', '2019-07-06 21:27:55.244905', NULL, 'admin', 'TE', '洗脱液', NULL, 'Tris+EDTA', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (20, '2019-07-06 21:23:48.887849', NULL, 'admin', '2019-07-06 21:28:00.047551', NULL, 'admin', 'SP', '样本', NULL, 'Sample', 6, '样本');
INSERT INTO "public"."material_type" VALUES (17, '2019-07-06 21:23:06.184532', NULL, 'admin', '2019-07-24 12:24:15.501257', NULL, 'admin', 'W1', '清洗液1', NULL, 'Wash1', 5, '试剂');
INSERT INTO "public"."material_type" VALUES (22, '2019-07-24 14:07:44.859665', NULL, 'admin', '2019-07-24 14:08:31.992725', NULL, 'admin', 'PL', 'PCR密封垫', NULL, 'PCRLid', 8, 'PCR密封垫');
INSERT INTO "public"."material_type" VALUES (23, '2019-07-24 14:07:59.300047', NULL, 'admin', '2019-07-24 14:08:41.131846', NULL, 'admin', 'PH', 'PCR密封垫支架', NULL, 'PCRLidHolder', 9, 'PCR密封垫支架');
INSERT INTO "public"."material_type" VALUES (6, '2019-07-06 21:18:55.804093', NULL, 'admin', '2019-07-26 11:34:15.083281', NULL, 'admin', 'TP', '普通无滤芯吸头', NULL, 'Tips', 4, '吸头');
INSERT INTO "public"."material_type" VALUES (24, '2019-07-27 16:02:04.591902', NULL, 'admin', '2019-07-29 10:57:24.133547', NULL, 'admin', 'TF', '普通有滤芯吸头', NULL, 'Tips', 4, '吸头');
INSERT INTO "public"."material_type" VALUES (25, '2019-07-27 16:02:45.611414', NULL, 'admin', '2019-07-29 10:57:38.729187', NULL, 'admin', 'AP', '导电无滤芯吸头', NULL, 'Tips', 4, '吸头');
INSERT INTO "public"."material_type" VALUES (26, '2019-07-27 16:02:59.451926', NULL, 'admin', '2019-07-29 10:57:53.264948', NULL, 'admin', 'AF', '导电有滤芯吸头', NULL, 'Tips', 4, '吸头');
INSERT INTO "public"."material_type" VALUES (2, '2019-07-06 21:07:00.042383', NULL, 'admin', '2019-09-06 16:28:15.041862', NULL, 'admin', 'RK', '料架', NULL, 'Rack', 1, '料架');
INSERT INTO "public"."material_type" VALUES (27, '2019-12-11 17:27:26.370791', NULL, 'admin', '2019-12-11 17:27:26.370794', NULL, 'admin', 'BP', '配平板', NULL, 'BalancedPlate', 10, '配平板');

-- ----------------------------
-- Table structure for material_type_config
-- ----------------------------
DROP TABLE IF EXISTS "public"."material_type_config";
CREATE TABLE "public"."material_type_config" (
  "id" int4 NOT NULL DEFAULT nextval('material_type_config_id_seq'::regclass),
  "material_type_id" int4,
  "config_key" text COLLATE "pg_catalog"."default",
  "config_default_value" text COLLATE "pg_catalog"."default",
  "sort" int4
)
;

-- ----------------------------
-- Records of material_type_config
-- ----------------------------
INSERT INTO "public"."material_type_config" VALUES (11, 3, 'AdhereTime', NULL, 150);
INSERT INTO "public"."material_type_config" VALUES (12, 3, 'Height', NULL, 30);
INSERT INTO "public"."material_type_config" VALUES (13, 3, 'ConsBottomOfZ', NULL, 80);
INSERT INTO "public"."material_type_config" VALUES (14, 3, 'Length', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (15, 3, 'CentriDuration', NULL, 180);
INSERT INTO "public"."material_type_config" VALUES (16, 3, 'CentriSpeed', NULL, 170);
INSERT INTO "public"."material_type_config" VALUES (17, 3, 'RowCounts', '8', 40);
INSERT INTO "public"."material_type_config" VALUES (18, 3, 'ColCounts', '12', 50);
INSERT INTO "public"."material_type_config" VALUES (19, 3, 'RowSpace', '9.0', 60);
INSERT INTO "public"."material_type_config" VALUES (20, 3, 'ColSpace', '9.0', 70);
INSERT INTO "public"."material_type_config" VALUES (21, 3, 'GraspOffsetOfZ', NULL, 90);
INSERT INTO "public"."material_type_config" VALUES (22, 3, 'GraspOffsetOfG', NULL, 100);
INSERT INTO "public"."material_type_config" VALUES (23, 3, 'GraspOffsetOfEpson', NULL, 110);
INSERT INTO "public"."material_type_config" VALUES (24, 3, 'FilmType', NULL, 120);
INSERT INTO "public"."material_type_config" VALUES (25, 3, 'PlateLocTemp', NULL, 130);
INSERT INTO "public"."material_type_config" VALUES (26, 3, 'PlateLocDuration', NULL, 140);
INSERT INTO "public"."material_type_config" VALUES (27, 3, 'Width', NULL, 20);
INSERT INTO "public"."material_type_config" VALUES (28, 3, 'LocationSpeed', NULL, 160);
INSERT INTO "public"."material_type_config" VALUES (29, 4, 'AdhereTime', NULL, 150);
INSERT INTO "public"."material_type_config" VALUES (30, 4, 'Height', NULL, 30);
INSERT INTO "public"."material_type_config" VALUES (31, 4, 'ConsBottomOfZ', NULL, 80);
INSERT INTO "public"."material_type_config" VALUES (32, 4, 'Length', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (33, 4, 'CentriDuration', NULL, 180);
INSERT INTO "public"."material_type_config" VALUES (34, 4, 'CentriSpeed', NULL, 170);
INSERT INTO "public"."material_type_config" VALUES (35, 4, 'RowCounts', '8', 40);
INSERT INTO "public"."material_type_config" VALUES (36, 4, 'ColCounts', '12', 50);
INSERT INTO "public"."material_type_config" VALUES (37, 4, 'RowSpace', '9.0', 60);
INSERT INTO "public"."material_type_config" VALUES (38, 4, 'ColSpace', '9.0', 70);
INSERT INTO "public"."material_type_config" VALUES (39, 4, 'GraspOffsetOfZ', NULL, 90);
INSERT INTO "public"."material_type_config" VALUES (40, 4, 'GraspOffsetOfG', NULL, 100);
INSERT INTO "public"."material_type_config" VALUES (41, 4, 'GraspOffsetOfEpson', NULL, 110);
INSERT INTO "public"."material_type_config" VALUES (42, 4, 'FilmType', NULL, 120);
INSERT INTO "public"."material_type_config" VALUES (43, 4, 'PlateLocTemp', NULL, 130);
INSERT INTO "public"."material_type_config" VALUES (44, 4, 'PlateLocDuration', NULL, 140);
INSERT INTO "public"."material_type_config" VALUES (45, 4, 'Width', NULL, 20);
INSERT INTO "public"."material_type_config" VALUES (46, 4, 'LocationSpeed', NULL, 160);
INSERT INTO "public"."material_type_config" VALUES (76, 7, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (77, 8, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (78, 9, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (79, 10, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (80, 11, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (81, 12, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (82, 13, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (83, 14, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (84, 15, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (85, 16, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (203, 6, 'Length', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (87, 18, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (204, 6, 'Width', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (205, 6, 'Height', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (206, 6, 'RowCounts', '8', NULL);
INSERT INTO "public"."material_type_config" VALUES (207, 6, 'ColCounts', '12', NULL);
INSERT INTO "public"."material_type_config" VALUES (208, 6, 'RowSpace', '9.0', NULL);
INSERT INTO "public"."material_type_config" VALUES (209, 6, 'ColSpace', '9.0', NULL);
INSERT INTO "public"."material_type_config" VALUES (210, 6, 'ConsBottomOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (211, 6, 'GraspOffsetOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (212, 6, 'GraspOffsetOfG', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (47, 5, 'AdhereTime', NULL, 150);
INSERT INTO "public"."material_type_config" VALUES (48, 5, 'Height', NULL, 30);
INSERT INTO "public"."material_type_config" VALUES (49, 5, 'ConsBottomOfZ', NULL, 80);
INSERT INTO "public"."material_type_config" VALUES (50, 5, 'Length', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (51, 5, 'CentriDuration', NULL, 180);
INSERT INTO "public"."material_type_config" VALUES (52, 5, 'CentriSpeed', NULL, 170);
INSERT INTO "public"."material_type_config" VALUES (53, 5, 'RowCounts', '8', 40);
INSERT INTO "public"."material_type_config" VALUES (54, 5, 'ColCounts', '12', 50);
INSERT INTO "public"."material_type_config" VALUES (55, 5, 'RowSpace', '9.0', 60);
INSERT INTO "public"."material_type_config" VALUES (56, 5, 'ColSpace', '9.0', 70);
INSERT INTO "public"."material_type_config" VALUES (57, 5, 'GraspOffsetOfZ', NULL, 90);
INSERT INTO "public"."material_type_config" VALUES (58, 5, 'GraspOffsetOfG', NULL, 100);
INSERT INTO "public"."material_type_config" VALUES (59, 5, 'GraspOffsetOfEpson', NULL, 110);
INSERT INTO "public"."material_type_config" VALUES (60, 5, 'FilmType', NULL, 120);
INSERT INTO "public"."material_type_config" VALUES (61, 5, 'PlateLocTemp', NULL, 130);
INSERT INTO "public"."material_type_config" VALUES (62, 5, 'PlateLocDuration', NULL, 140);
INSERT INTO "public"."material_type_config" VALUES (63, 5, 'Width', NULL, 20);
INSERT INTO "public"."material_type_config" VALUES (64, 5, 'LocationSpeed', NULL, 160);
INSERT INTO "public"."material_type_config" VALUES (213, 6, 'GraspOffsetOfEpson', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (88, 19, 'Storage', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (89, 20, 'Property', NULL, 10);
INSERT INTO "public"."material_type_config" VALUES (90, 20, 'Storage', NULL, 20);
INSERT INTO "public"."material_type_config" VALUES (247, 2, 'RackLength', '141', NULL);
INSERT INTO "public"."material_type_config" VALUES (248, 2, 'RackWidth', '99', NULL);
INSERT INTO "public"."material_type_config" VALUES (249, 2, 'RackHeight', '620.1', NULL);
INSERT INTO "public"."material_type_config" VALUES (250, 2, 'RackBarcodeHeight', '578.5', NULL);
INSERT INTO "public"."material_type_config" VALUES (147, 17, 'Storage', '', NULL);
INSERT INTO "public"."material_type_config" VALUES (252, 2, 'LevelLength', '129', NULL);
INSERT INTO "public"."material_type_config" VALUES (253, 2, 'LevelWidth', '87', NULL);
INSERT INTO "public"."material_type_config" VALUES (256, 24, 'Length', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (257, 24, 'Width', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (258, 24, 'Height', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (259, 24, 'RowCounts', '8', NULL);
INSERT INTO "public"."material_type_config" VALUES (260, 24, 'ColCounts', '12', NULL);
INSERT INTO "public"."material_type_config" VALUES (261, 24, 'RowSpace', '9.0', NULL);
INSERT INTO "public"."material_type_config" VALUES (262, 24, 'ColSpace', '9.0', NULL);
INSERT INTO "public"."material_type_config" VALUES (263, 24, 'ConsBottomOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (264, 24, 'GraspOffsetOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (265, 24, 'GraspOffsetOfG', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (266, 24, 'GraspOffsetOfEpson', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (267, 25, 'Length', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (268, 25, 'Width', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (269, 25, 'Height', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (270, 25, 'RowCounts', '8', NULL);
INSERT INTO "public"."material_type_config" VALUES (271, 25, 'ColCounts', '12', NULL);
INSERT INTO "public"."material_type_config" VALUES (272, 25, 'RowSpace', '9.0', NULL);
INSERT INTO "public"."material_type_config" VALUES (273, 25, 'ColSpace', '9.0', NULL);
INSERT INTO "public"."material_type_config" VALUES (192, 22, 'Length', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (193, 22, 'Width', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (194, 22, 'Height', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (195, 22, 'GraspOffsetOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (196, 22, 'GraspOffsetOfG', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (197, 23, 'Length', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (198, 23, 'Width', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (199, 23, 'Height', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (200, 23, 'GraspOffsetOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (201, 23, 'GraspOffsetOfG', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (202, 23, 'GraspOffsetOfEpson', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (274, 25, 'ConsBottomOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (275, 25, 'GraspOffsetOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (276, 25, 'GraspOffsetOfG', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (277, 25, 'GraspOffsetOfEpson', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (278, 26, 'Length', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (279, 26, 'Width', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (280, 26, 'Height', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (281, 26, 'RowCounts', '8', NULL);
INSERT INTO "public"."material_type_config" VALUES (282, 26, 'ColCounts', '12', NULL);
INSERT INTO "public"."material_type_config" VALUES (283, 26, 'RowSpace', '9.0', NULL);
INSERT INTO "public"."material_type_config" VALUES (284, 26, 'ColSpace', '9.0', NULL);
INSERT INTO "public"."material_type_config" VALUES (285, 26, 'ConsBottomOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (286, 26, 'GraspOffsetOfZ', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (287, 26, 'GraspOffsetOfG', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (288, 26, 'GraspOffsetOfEpson', NULL, NULL);
INSERT INTO "public"."material_type_config" VALUES (251, 2, 'LevelCounts', '0', NULL);
INSERT INTO "public"."material_type_config" VALUES (254, 2, 'LevelBarcodeHeight', '0', NULL);
INSERT INTO "public"."material_type_config" VALUES (255, 2, 'LevelHeight', '0', NULL);
INSERT INTO "public"."material_type_config" VALUES (289, 27, 'Length', '0', 10);
INSERT INTO "public"."material_type_config" VALUES (290, 27, 'Width', '0', 20);
INSERT INTO "public"."material_type_config" VALUES (291, 27, 'Height', '0', 30);
INSERT INTO "public"."material_type_config" VALUES (292, 27, 'Weight', '0', 40);
INSERT INTO "public"."material_type_config" VALUES (293, 27, 'GraspOffsetOfEpson', '0', 50);

-- ----------------------------
-- Table structure for sys_lookup
-- ----------------------------
DROP TABLE IF EXISTS "public"."sys_lookup";
CREATE TABLE "public"."sys_lookup" (
  "id" int4 NOT NULL DEFAULT nextval('sys_lookup_id_seq'::regclass),
  "create_time" timestamp(6),
  "create_user_id" int4,
  "create_user_name" text COLLATE "pg_catalog"."default",
  "modify_time" timestamp(6),
  "modify_user_id" int4,
  "modify_user_name" text COLLATE "pg_catalog"."default",
  "look_up_code" text COLLATE "pg_catalog"."default",
  "code" text COLLATE "pg_catalog"."default",
  "name" text COLLATE "pg_catalog"."default",
  "desc" text COLLATE "pg_catalog"."default",
  "sort" int4
)
;

-- ----------------------------
-- Records of sys_lookup
-- ----------------------------
INSERT INTO "public"."sys_lookup" VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, 'config_value_type', '10', 'Text', NULL, 20);
INSERT INTO "public"."sys_lookup" VALUES (2, NULL, NULL, NULL, NULL, NULL, NULL, 'config_value_type', '20', 'Number', NULL, 10);



-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS "public"."sys_role";
CREATE TABLE "public"."sys_role" (
  "id" int4 NOT NULL DEFAULT nextval('sys_role_id_seq'::regclass),
  "name" varchar(100) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "create_user_id" int4,
  "create_user_name" varchar(255) COLLATE "pg_catalog"."default",
  "create_time" timestamp(6),
  "modify_user_id" int4,
  "modify_user_name" varchar(255) COLLATE "pg_catalog"."default",
  "modify_time" timestamp(6)
)
;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO "public"."sys_role" VALUES (1, 'administators', 'administators', 1, 'Super Administrator', '2019-05-17 15:34:54.466588', 1, 'Super Administrator', '2019-05-17 15:34:54.46685');

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS "public"."sys_user";
CREATE TABLE "public"."sys_user" (
  "id" int4 NOT NULL DEFAULT nextval('sys_user_id_seq'::regclass),
  "user_name" varchar(255) COLLATE "pg_catalog"."default",
  "real_name" varchar(255) COLLATE "pg_catalog"."default",
  "password" varchar(255) COLLATE "pg_catalog"."default",
  "email" varchar(255) COLLATE "pg_catalog"."default",
  "mobile" varchar(255) COLLATE "pg_catalog"."default",
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "last_login_time" timestamp(6),
  "create_user_id" int4,
  "create_user_name" varchar(255) COLLATE "pg_catalog"."default",
  "create_time" timestamp(6),
  "modify_user_id" int4,
  "modify_user_name" varchar(255) COLLATE "pg_catalog"."default",
  "modify_time" timestamp(6)
)
;

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO "public"."sys_user" VALUES (1, 'admin', 'Super Administrator', '123456', '', '', '', '2019-05-17 07:35:23.25', 1, 'Super Administrator', '2019-05-17 15:35:53.986283', 1, 'Super Administrator', '2019-05-17 15:35:53.986285');


-- ----------------------------
-- Alter sequences owned by
-- ----------------------------

ALTER SEQUENCE "public"."attachment_id_seq"
OWNED BY "public"."attachment"."id";
SELECT setval('"public"."attachment_id_seq"', 73, true);
ALTER SEQUENCE "public"."material_brand_id_seq"
OWNED BY "public"."material_brand"."id";
SELECT setval('"public"."material_brand_id_seq"', 268, true);
ALTER SEQUENCE "public"."material_category_config_id_seq"
OWNED BY "public"."material_category_config"."id";
SELECT setval('"public"."material_category_config_id_seq"', 99, false);
ALTER SEQUENCE "public"."material_category_id_seq"
OWNED BY "public"."material_category"."id";
SELECT setval('"public"."material_category_id_seq"', 18, true);
ALTER SEQUENCE "public"."material_config_id_seq"
OWNED BY "public"."material_config"."id";
SELECT setval('"public"."material_config_id_seq"', 2699, true);
ALTER SEQUENCE "public"."material_id_seq"
OWNED BY "public"."material"."id";
SELECT setval('"public"."material_id_seq"', 86, true);
ALTER SEQUENCE "public"."material_serial_no_id_seq"
OWNED BY "public"."material_serial_no"."id";
SELECT setval('"public"."material_serial_no_id_seq"', 41, false);
ALTER SEQUENCE "public"."material_type_config_id_seq"
OWNED BY "public"."material_type_config"."id";
SELECT setval('"public"."material_type_config_id_seq"', 295, false);
ALTER SEQUENCE "public"."material_type_id_seq"
OWNED BY "public"."material_type"."id";
SELECT setval('"public"."material_type_id_seq"', 29, false);
ALTER SEQUENCE "public"."sys_lookup_id_seq"
OWNED BY "public"."sys_lookup"."id";
SELECT setval('"public"."sys_lookup_id_seq"', 10, false);
ALTER SEQUENCE "public"."sys_role_id_seq"
OWNED BY "public"."sys_role"."id";
SELECT setval('"public"."sys_role_id_seq"', 3, true);
ALTER SEQUENCE "public"."sys_user_id_seq"
OWNED BY "public"."sys_user"."id";
SELECT setval('"public"."sys_user_id_seq"', 3, true);

-- ----------------------------
-- Primary Key structure for table attachment
-- ----------------------------
ALTER TABLE "public"."attachment" ADD CONSTRAINT "PK_attachment" PRIMARY KEY ("id");



-- ----------------------------
-- Primary Key structure for table material
-- ----------------------------
ALTER TABLE "public"."material" ADD CONSTRAINT "PK_material" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table material_brand
-- ----------------------------
ALTER TABLE "public"."material_brand" ADD CONSTRAINT "PK_material_brand" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table material_category
-- ----------------------------
ALTER TABLE "public"."material_category" ADD CONSTRAINT "PK_material_category" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table material_category_config
-- ----------------------------
ALTER TABLE "public"."material_category_config" ADD CONSTRAINT "PK_material_category_config" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table material_config
-- ----------------------------
ALTER TABLE "public"."material_config" ADD CONSTRAINT "PK_material_config" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table material_serial_no
-- ----------------------------
ALTER TABLE "public"."material_serial_no" ADD CONSTRAINT "PK_material_serial_no" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table material_type
-- ----------------------------
ALTER TABLE "public"."material_type" ADD CONSTRAINT "PK_material_type" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table material_type_config
-- ----------------------------
ALTER TABLE "public"."material_type_config" ADD CONSTRAINT "PK_material_type_config" PRIMARY KEY ("id");
-- ----------------------------
-- Primary Key structure for table sys_role
-- ----------------------------
ALTER TABLE "public"."sys_role" ADD CONSTRAINT "role_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sys_user
-- ----------------------------
ALTER TABLE "public"."sys_user" ADD CONSTRAINT "sys_user_pkey" PRIMARY KEY ("id");
-- ----------------------------
-- Primary Key structure for table sys_lookup
-- ----------------------------
ALTER TABLE "public"."sys_lookup" ADD CONSTRAINT "PK_sys_lookup" PRIMARY KEY ("id");
