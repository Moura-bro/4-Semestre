
import { TaskItem } from '../taskitem/TaskItem';
import { TaskListStyle } from './TaskListStyle';
import { ScrollView, Text, View } from 'react-native';

export const TaskList = () => {
    return(
     <ScrollView style={TaskListStyle.taskListContainer}>
       <TaskItem/>
       <TaskItem/>
       <TaskItem/>
       <TaskItem/>
       <TaskItem/>
       <TaskItem/>
       <TaskItem/>
       <TaskItem/>
       <TaskItem/>
       <TaskItem/>
     </ScrollView>
    )
}