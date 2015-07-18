SELECT users.username ,Users.fullname, job_ads.title AS Job, salaries.from_value as `From Value`, salaries.to_value as `To Value`FROM job_ad_applications
left join job_ads ON job_ads.id = job_ad_applications.job_ad_id
left JOIN users ON users.id = job_ad_applications.user_id
left JOIN salaries ON salaries.id = job_ads.salary_id
ORDER BY users.username, job_ads.title
INTO OUTFILE 'C:/Users/Elina Pavlova/Desktop/result.csv'
FIELDS TERMINATED BY ','
LINES TERMINATED BY '\n';