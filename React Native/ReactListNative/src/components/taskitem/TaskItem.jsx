import { Image, Text, View } from 'react-native';
import { TaskItemStyle } from './TaskItemStyle';
import Lapiz from '../../../assets/lapiz.png';
import lixo from '../../../assets/lixo.png';

export const TaskItem = () => {
    return(
        <View style={TaskItemStyle.cardBox}>
            <Text style={TaskItemStyle.cardBoxText} >Task Item Components</Text>

            <Image source={Lapiz}/>
            <Image source={lixo}/>
        </View>
    )
}