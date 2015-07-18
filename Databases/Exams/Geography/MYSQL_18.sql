select training_centers.name as `training center`,timetable.start_date as `start date`,courses.name as `course name`,courses.description as `more info`
 FROM training_centers join timetable on training_centers.idtraining_centers = timetable.training_center_id
join courses on courses.idcourses = timetable.course_id
order by `start_date`,timetable.idcourse_timetable
INTO OUTFILE 'C:/Users/Elina Pavlova/Desktop/result.csv'
FIELDS TERMINATED BY ', '
LINES TERMINATED BY '\n';