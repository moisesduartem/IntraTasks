import React from 'react';

import {ActivityIndicator} from 'react-native';
import {colors} from 'react-native-elements';

import * as S from './style';

export function AppScreen({loading, children}) {
  return loading ? (
    <S.Loading>
      <ActivityIndicator size="large" color={colors.primary} />
    </S.Loading>
  ) : (
    <>{children}</>
  );
}
