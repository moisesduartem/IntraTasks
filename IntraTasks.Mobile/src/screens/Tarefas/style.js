import {Text, View} from 'react-native';
import {colors} from 'react-native-elements';
import styled from 'styled-components/native';

export const Card = {
  Container: styled(View)`
    padding: 5px;
  `,
  Body: styled(View)`
    padding-top: 10px;
    padding-bottom: 10px;
  `,
};

export const Note = {
  Container: styled(View)`
    padding-top: 10px;
    padding-bottom: 10px;
  `,
  Text: styled(View)`
    font-size: 16px;
    font-weight: 700;
  `,
};

export const Task = {
  Title: styled(Text)`
    font-size: 20px;
  `,
  Situation: styled(Text)`
    color: ${props => (props?.situation === 2 ? colors.success : colors.error)};
  `,
};

export const Item = {
  Options: styled(View)`
    flex-direction: row;
    justify-content: flex-end;
    width: 100%;
  `,
  Button: styled(View)`
    margin-left: 5px;
    margin-right: 5px;
  `,
};
