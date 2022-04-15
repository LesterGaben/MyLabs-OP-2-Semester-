from Structs import*

def input_in_file(file_name):
    print("Please enter tasks in ascending order of start time\n")
    with open(file_name, "wb") as my_file:
        task = Task()
        answer = "Yes"
        while(answer != "No"):
            task.name = input("Enter name of task: ")
            task.start_time = input("Enter start time of task(hours:minutes): ")
            task.duration = int(input("Enter duration in minutes of task: "))
            answer = input("Continue typing? (Any other input/ No): ")
            print("=======================")
            my_file.write((task.name + "   " + task.start_time + "   " + str(task.duration) + "\n").encode())
    pass


def output_text_from_file(file_name):
    print("\nFile contents " + file_name + ":")
    with open(file_name, "rb") as my_file:
        print(my_file.read().decode())
    pass


def input_in_new_file(file_name, new_file_name):
    with open(file_name, "rb") as my_file:
        with open(new_file_name, "wb") as my_new_file:
            for line in my_file.readlines():
                task_list = line.decode().split("   ")
                start_time = Time()
                end_time = Time()
                start_time.hours, start_time.minutes = map(int, task_list[1].split(":"))
                end_time.hours, end_time.minutes = calculate_time(task_list[1], task_list[2])
                if (((start_time.hours == 12 and start_time.minutes == 45) or start_time.hours > 12) and (end_time.hours < 17 or (end_time.hours == 17 and end_time.minutes <= 30))):
                    my_new_file.write(line)
    pass


def calculate_time(time, duration):
    hours, minutes = map(int, time.split(":"))
    minutes += int(duration)
    if (minutes >= 60):
        hours += minutes // 60
        if (hours >= 24): hours -= 24
        while (minutes >= 60): minutes -= 60
    return hours, minutes


def create_free_time_list(file_name):
    time_list = []
    with open(file_name, "rb") as my_file:
        for line in my_file.readlines():
            task_list = line.decode().split("   ")
            time_period = Time_Period()
            time_period.start.hours, time_period.start.minutes = map(int, task_list[1].split(":"))
            time_period.end.hours, time_period.end.minutes = calculate_time(task_list[1], task_list[2])
            time_list.append(time_period)
    free_time_list = []
    for i in range(1, len(time_list)):
        if ((time_list[i - 1].end.hours < time_list[i].start.hours) or (time_list[i - 1].end.hours == time_list[i].start.hours and time_list[i - 1].end.minutes < time_list[i].start.minutes)):
            time_period = Time_Period()
            time_period.start.hours = time_list[i - 1].end.hours
            time_period.start.minutes = time_list[i - 1].end.minutes
            time_period.end.hours = time_list[i].start.hours
            time_period.end.minutes = time_list[i].start.minutes
            free_time_list.append(time_period)
    return free_time_list


def output_free_time(free_time_list):
    print("\nFree time:")
    for time_period in free_time_list:
        if (time_period.start.hours < time_period.end.hours):
            duration = time_period.end.minutes + ((time_period.end.hours - time_period.start.hours) * 60 - time_period.start.minutes)
        else:
            duration = time_period.end.minutes - time_period.start.minutes
        start_minutes = "0" + str(time_period.start.minutes) if (time_period.start.minutes < 10) else str(time_period.start.minutes)
        end_minutes = "0" + str(time_period.end.minutes) if (time_period.end.minutes < 10) else str(time_period.end.minutes)
        start_time = str(time_period.start.hours) + ":" + start_minutes
        end_time = str(time_period.end.hours) + ":" + end_minutes
        print("Time interval: " + start_time + "-" + end_time + "    Duration: " + str(duration) + " minutes")
    print()
    pass