-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema university
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `university` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `university` ;

-- -----------------------------------------------------
-- Table `university`.`faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`faculties` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  UNIQUE INDEX `id_UNIQUE` (`Id` ASC)  COMMENT '')
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `university`.`departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`departments` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL COMMENT '',
  `FacultyId` INT(11) NULL DEFAULT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC)  COMMENT '',
  INDEX `FK_Departments_Faculties_idx` (`FacultyId` ASC)  COMMENT '',
  CONSTRAINT `fk_departments_faculties_faculty_id`
    FOREIGN KEY (`FacultyId`)
    REFERENCES `university`.`faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `university`.`courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`courses` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL COMMENT '',
  `DepartmentId` INT(11) NULL DEFAULT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC)  COMMENT '',
  INDEX `fk_courses_departments_department_id_idx` (`DepartmentId` ASC)  COMMENT '',
  CONSTRAINT `fk_courses_departments_department_id`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `university`.`departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `university`.`professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`professors` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL COMMENT '',
  `DepartmentId` INT(11) NULL DEFAULT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC)  COMMENT '',
  INDEX `fk_professors_departments_department_id_idx` (`DepartmentId` ASC)  COMMENT '',
  CONSTRAINT `fk_professors_departments_department_id`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `university`.`departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `university`.`professors_courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`professors_courses` (
  `ProfessorId` INT(11) NOT NULL COMMENT '',
  `CourseId` INT(11) NOT NULL COMMENT '',
  INDEX `fk_professors_courses_professors_course_id_idx` (`CourseId` ASC, `ProfessorId` ASC)  COMMENT '',
  INDEX `fk_professors_courses_professors_professor_id` (`ProfessorId` ASC)  COMMENT '',
  CONSTRAINT `fk_professors_courses_courses_course_id`
    FOREIGN KEY (`CourseId`)
    REFERENCES `university`.`courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_professors_courses_professors_professor_id`
    FOREIGN KEY (`ProfessorId`)
    REFERENCES `university`.`professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `university`.`titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`titles` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC)  COMMENT '')
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `university`.`professors_titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`professors_titles` (
  `ProfessorId` INT(11) NOT NULL COMMENT '',
  `TitleId` INT(11) NOT NULL COMMENT '',
  INDEX `fk_professors_titles_professors_professor_id_idx` (`ProfessorId` ASC)  COMMENT '',
  INDEX `fk_professors_titles_titles_title_id_idx` (`TitleId` ASC)  COMMENT '',
  CONSTRAINT `fk_professors_titles_professors_professor_id`
    FOREIGN KEY (`ProfessorId`)
    REFERENCES `university`.`professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_professors_titles_titles_title_id`
    FOREIGN KEY (`TitleId`)
    REFERENCES `university`.`titles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `university`.`students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`students` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT COMMENT '',
  `Name` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL COMMENT '',
  PRIMARY KEY (`Id`)  COMMENT '',
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC)  COMMENT '')
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `university`.`students_courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `university`.`students_courses` (
  `StudentId` INT(11) NOT NULL COMMENT '',
  `CourseId` INT(11) NOT NULL COMMENT '',
  INDEX `fk_students_courses_students_student_id_idx` (`StudentId` ASC)  COMMENT '',
  INDEX `fk_students_courses_courses_course_id_idx` (`CourseId` ASC)  COMMENT '',
  CONSTRAINT `fk_students_courses_courses_course_id`
    FOREIGN KEY (`CourseId`)
    REFERENCES `university`.`courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_students_courses_students_student_id`
    FOREIGN KEY (`StudentId`)
    REFERENCES `university`.`students` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
