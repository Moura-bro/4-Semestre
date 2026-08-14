import {Text, View } from 'react-native';
import { FooterStyle } from './FooterStyle';

export const Footer = () => {
    return(
        <View >
            <Text style={FooterStyle.footerText}>2026, React List - Todos os direitos reservados</Text>
        </View>
    )
}