import React from 'react';

import {ActivityIndicator} from 'react-native';
import {colors} from 'react-native-elements';

import * as S from './style';

export function AppScreen({loading, message = null, children}) {
  if (!message) {
    return loading ? (
      <S.Loading>
        <ActivityIndicator size="large" color={colors.primary} />
      </S.Loading>
    ) : (
      <>{children}</>
    );
  }

  return <S.Message>{message}</S.Message>;
}
