import {View, Text} from 'react-native';
import styled from 'styled-components';

export const Loading = styled(View)`
  flex: 1;
  justify-content: center;
  align-items: center;
  height: 100%;
`;

export const Message = styled(Text)`
  margin-top: 20px;
  text-align: center;
  font-size: 17px;
`;
