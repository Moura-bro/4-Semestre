import { Text, View } from "react-native"
import { HearderStyle } from "./HeaderStyle"

export const Header = () => {
    return(
        <View style = {HearderStyle.header}>
            <Text style = {HearderStyle.headerText}>React List</Text>
        </View>
    )

}